Shader "Custom/cloud"
{
Properties
{
    _Color("Color", Color) = (1, 1, 1, 1)
    _Intensity("Intensity", Range(0, 1)) = 0.1
    [IntRange] _Loop("Loop", Range(0, 128)) = 32
      _NoiseScale("NoiseScale", Range(0, 100)) = 5
    _Radius("Radius", Range(0, 2)) = 1.0 
}

CGINCLUDE

#include "UnityCG.cginc"

struct appdata
{
    float4 vertex : POSITION;
};

struct v2f
{
    float4 vertex   : SV_POSITION;
    float3 worldPos : TEXCOORD1;
};

#define MAX_LOOP 100
float4 _Color;
float _Intensity;
int _Loop;
float _NoiseScale;
float _Radius;


// ref. https://www.shadertoy.com/view/lss3zr
inline float hash(float n)
{
    return frac(sin(n) * 43758.5453);
}

inline float noise(float3 x)
{
    float3 p = floor(x);
    float3 f = frac(x);
    f = f * f * (3.0 - 2.0 * f);
    float n = p.x + p.y * 57.0 + 113.0 * p.z;
    float res = 
        lerp(lerp(lerp(hash(n +   0.0), hash(n +   1.0), f.x),
                  lerp(hash(n +  57.0), hash(n +  58.0), f.x), f.y),
             lerp(lerp(hash(n + 113.0), hash(n + 114.0), f.x),
                  lerp(hash(n + 170.0), hash(n + 171.0), f.x), f.y), f.z);
    return res;
}

inline float fbm(float3 p)
{
    float3x3 m = float3x3(
        +0.00, +0.80, +0.60,
        -0.80, +0.36, -0.48,
        -0.60, -0.48, +0.64);
    float f = 0.0;
    f += 0.5 * noise(p); p = mul(m, p) * 2.02;
    f += 0.3 * noise(p); p = mul(m, p) * 2.03;
    f += 0.2 * noise(p);
    return f;
}

inline float densityFunction(float3 p)
{   
    return fbm(p * _NoiseScale) - length(p / _Radius);
}

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    // ポリゴン表面の座標がフラグメントシェーダで使えるようにする
    o.worldPos = mul(unity_ObjectToWorld, v.vertex);
    return o;
}

float4 frag(v2f i) : SV_Target
{
    // ワールド空間でのポリゴン表面座標とそこへのカメラからの向き
    float3 worldPos = i.worldPos;
    float3 worldDir = normalize(worldPos - _WorldSpaceCameraPos);

    // オブジェクト空間に変換
    float3 localPos = mul(unity_WorldToObject, float4(worldPos, 1.0));
    float3 localDir = UnityWorldToObjectDir(worldDir);

    // オブジェクト空間でのレイのステップ長
    float step = 1.0 / _Loop;
    float3 localStep = localDir * step;

    // レイを通過させて得られる透過率
    float alpha = 0.0;

    for (int i = 0; i < _Loop; ++i)
    {
        // ポリゴン中心ほど大きな値が返ってくる
        float density = densityFunction(localPos);

        // 球の外側ではマイナスの値が返ってくるのでそれを弾く
        if (density > 0.001)
        {
            // 透過率の足し合わせ
            alpha += (1.0 - alpha) * density * _Intensity;
        }

        // ステップを進める
        localPos += localStep;

        // ポリゴンの外に出たら終わり
        if (!all(max(0.5 - abs(localPos), 0.0))) break;
    }

    float4 color = _Color;
    color.a *= alpha;
    return color;
}

ENDCG

SubShader
{

Tags 
{ 
    "Queue" = "Transparent"
    "RenderType" = "Transparent" 
}

Pass
{
    Cull Back
    ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha 
    Lighting Off

    CGPROGRAM
    #pragma vertex vert
    #pragma fragment frag
    ENDCG
}

}

}
