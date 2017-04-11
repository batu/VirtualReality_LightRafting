// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33649,y:32394,varname:node_4013,prsc:2|emission-7203-OUT,voffset-9135-OUT;n:type:ShaderForge.SFN_NormalVector,id:9097,x:33010,y:32878,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9135,x:33461,y:32728,varname:node_9135,prsc:2|A-7203-OUT,B-9097-OUT,C-5118-OUT;n:type:ShaderForge.SFN_Vector1,id:5118,x:33010,y:33024,varname:node_5118,prsc:2,v1:0.2;n:type:ShaderForge.SFN_TexCoord,id:8200,x:31870,y:32505,varname:node_8200,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:3877,x:32034,y:32505,varname:node_3877,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8200-U;n:type:ShaderForge.SFN_Multiply,id:9559,x:32453,y:32567,varname:node_9559,prsc:2|A-4063-OUT,B-9019-OUT,C-8764-OUT;n:type:ShaderForge.SFN_Sin,id:6051,x:32684,y:32567,varname:node_6051,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_RemapRange,id:8879,x:32618,y:32379,varname:node_8879,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6051-OUT;n:type:ShaderForge.SFN_Lerp,id:9488,x:32988,y:32620,varname:node_9488,prsc:2|A-6894-RGB,B-9771-RGB,T-8879-OUT;n:type:ShaderForge.SFN_Color,id:6894,x:32881,y:32298,ptovrint:False,ptlb:5,ptin:_5,varname:_5,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:9771,x:33062,y:32310,ptovrint:False,ptlb:node_9771,ptin:_node_9771,varname:_node_9771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:4063,x:32282,y:32348,varname:node_4063,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:9019,x:32226,y:32567,varname:node_9019,prsc:2|A-3877-OUT,B-2349-TSL;n:type:ShaderForge.SFN_Time,id:2349,x:31933,y:32733,varname:node_2349,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:7203,x:33187,y:32620,varname:node_7203,prsc:2|IN-9488-OUT;n:type:ShaderForge.SFN_Tau,id:8764,x:32259,y:32722,varname:node_8764,prsc:2;proporder:6894-9771;pass:END;sub:END;*/

Shader "Shader Forge/Ink1" {
    Properties {
        _5 ("5", Color) = (0,0,0,1)
        _node_9771 ("node_9771", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _5;
            uniform float4 _node_9771;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2349 = _Time + _TimeEditor;
                float3 node_7203 = saturate(lerp(_5.rgb,_node_9771.rgb,(sin((4.0*(o.uv0.r.r+node_2349.r)*6.28318530718))*0.5+0.5)));
                v.vertex.xyz += (node_7203*v.normal*0.2);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_2349 = _Time + _TimeEditor;
                float3 node_7203 = saturate(lerp(_5.rgb,_node_9771.rgb,(sin((4.0*(i.uv0.r.r+node_2349.r)*6.28318530718))*0.5+0.5)));
                float3 emissive = node_7203;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _5;
            uniform float4 _node_9771;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_2349 = _Time + _TimeEditor;
                float3 node_7203 = saturate(lerp(_5.rgb,_node_9771.rgb,(sin((4.0*(o.uv0.r.r+node_2349.r)*6.28318530718))*0.5+0.5)));
                v.vertex.xyz += (node_7203*v.normal*0.2);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
