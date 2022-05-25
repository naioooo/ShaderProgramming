#version 450

layout(location=0) out vec4 FragColor;

in vec4 v_Color;
in vec4 v_ColorOverride;

const float PI = 3.141592;

uniform vec3 u_Points[10];
uniform float u_Time;

vec4 CrossPattern()
{
	vec4 returnValue = vec4(1);
	float XAxis = sin(10 * v_Color.x*2*PI + PI/2 + PI ); // 끝 깔끔 시험
	float YAxis = sin(10 * v_Color.y*2*PI + PI/2  + PI);
	
	float resultColor = max(XAxis, YAxis);
	returnValue = vec4(resultColor);

	return returnValue;
}

vec4 DrawCircle()
{
	float dis = distance(v_Color.xy,vec2(0.5,0.5));
	vec4 newColor =vec4(0,0,0,0);

	// 원 그리기
	if(dis < 0.5)
	{
		newColor = vec4(1,1,1,1);
	}
	else
	{
		newColor =vec4(0,0,0,0);
	}

	return newColor;
}

vec4 DrawCircleLine()
{
	float dis = distance(v_Color.xy,vec2(0.5,0.5));
	vec4 newColor =vec4(0,0,0,0);

	// 두께가 0.02인 원 그리기
	if(dis> 0.29 && dis < 0.31)
	{
		newColor = vec4(1,1,1,1);
	}
	else
	{
		newColor =vec4(0,0,0,0);
	}

	return newColor;
}

vec4 DrawMultipleCircles()
{
	float dis = distance(v_Color.xy,vec2(0.5,0.5));
	float temp = sin(10 * dis*4*PI);
	return vec4(temp);
}

vec4 DrawCircles()
{
	vec4 returnValue = vec4(0);

	for(int i = 0; i < 10; i++)
	{
		float dis = distance(u_Points[i].xy,v_Color.xy);
		float temp = sin(20 * dis*4*PI - (u_Time*100));

		if(dis < u_Time)
		{
			returnValue += vec4(temp);
		}


		/*
		if(dis < 0.1f)
		{
			returnValue = vec4
		}
		*/
	}	

	return returnValue;
}

vec4 RadarCircle()
{
	vec4 returnColor = vec4(0);	

	float d = distance(vec2(0.5f, 0), v_Color.xy);
	float sinValue = sin(d*2*PI - (100 * u_Time));
	sinValue = clamp(pow(sinValue, 4),0 ,1);
	returnColor = vec4(0.5* sinValue);	


	for(int i = 0; i < 10; i++)
	{
		float dis = distance(u_Points[i].xy,v_Color.xy);

		if(dis < 0.1)
		{
			returnColor += 20*vec4(0, 10*sinValue*(0.1-dis), 0 ,0);
		}
		
	}

	return returnColor;
}

void main()
{
	//FragColor =   DrawCircles();
	//FragColor = DrawMultipleCircles();
	//FragColor = CrossPattern();
	//FragColor = DrawCircle();
	//FragColor = DrawCircleLine();
	FragColor = RadarCircle() * v_ColorOverride;
}
