#version 450

in vec3 a_Position;

out vec2 v_TexCoord;

void main()
{
	gl_Position = vec4(a_Position, 1);
	v_TexCoord = vec2((a_Position.x + 1.0f)/2.0f, (a_Position.y +1.0f)/2.0f);
}
