#version 450

layout(location=0) out vec4 FragColor;

in vec2 v_TexCoord;

uniform float u_Time;

const float PI = 3.141592f;

void main()
{
	float sinValue = 0.5f * sin(2.0f * v_TexCoord.x *2.0f * PI + (u_Time));
	if(v_TexCoord.y * 2.0f - 1.0f < sinValue + 0.01f && v_TexCoord.y * 2.0f - 1.0f > sinValue -0.01f)
	{
		FragColor = vec4(1);
	}
	else
	{
		FragColor = vec4(0);
	}
	//FragColor = vec4(sinValue);
}
