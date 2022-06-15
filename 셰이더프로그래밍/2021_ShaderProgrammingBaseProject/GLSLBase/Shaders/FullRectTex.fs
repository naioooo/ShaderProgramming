#version 450

layout(location=0) out vec4 FragColor;

//in vec2 v_TexCoord;

uniform sampler2D u_Sampler;

void main()
{
	FragColor = texture(u_Sampler, v_TexCoord);
}
