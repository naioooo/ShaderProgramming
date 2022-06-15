#version 450

in vec3 a_Position;

const float PI = 3.141592;

out vec4 v_Color;

uniform float u_Time;

void flag()
{
	// ±ê¹ß
    vec3 newPos = a_Position;

	float xDis = a_Position.x + 0.5;
	float Dis = distance(a_Position.xy, vec2(-0.5, 0.0));

	float XValue = xDis * 0.5 * sin( Dis * 2.0 * PI - u_Time);
	float YValue = xDis * 0.5 * sin( Dis * 2.0 * PI - u_Time);

	newPos.x += XValue;
	newPos.y += YValue;

	gl_Position = vec4(newPos, 1);
	v_Color = vec4(sin(( a_Position.x + 0.5) * 2.0 * PI - u_Time) + 1.0 / 2.0);	
}

void flow()
{
    vec3 newPos = a_Position;

	float Dis = distance(a_Position.xy, vec2(0.0, 0.0));
	float temp = sin(Dis* 6 *PI - u_Time);

	v_Color = vec4(temp);
	gl_Position = vec4(newPos, 1);
}

void main()
{
   //flag();
   flow();
}
