#version 450

layout(location=0) out vec4 FragColor;

in vec2 v_TexCoord;

uniform sampler2D u_TexSampler;
uniform sampler2D u_TexSampler1;

uniform int u_Time;


vec4 Filp()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	newTexCoord = vec2(v_TexCoord.x, 1.0 - v_TexCoord.y);

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 Mirror()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	newTexCoord.y = abs(2.0f *(v_TexCoord.y - 0.5f));

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}
 
vec4 garosambunhal()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

    //fract, floor
	newTexCoord.x = fract(v_TexCoord.x * 3.0f);
	newTexCoord.y =  newTexCoord.y / 3.0 +  (floor((1 - v_TexCoord.x) * 3.0f) /3.0f); 

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 brick()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	//º¯¼öÈ­
	float count = 4;

	newTexCoord.x = fract(v_TexCoord.x * count) + floor(v_TexCoord.y * count) * 0.5f;
	newTexCoord.y = fract(v_TexCoord.y * count);

	returnValue = texture(u_TexSampler, newTexCoord);
	return returnValue;
}

vec4 TwoTexture()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;

	newTexCoord.x = fract(v_TexCoord.x *2.0f);	
	if(v_TexCoord.x > 0.5f)
	{
		returnValue = texture(u_TexSampler1, newTexCoord);
	}
	else
	{
		returnValue = texture(u_TexSampler, newTexCoord);
	}
	
	return returnValue;
}

vec4 MixTexture()
{
	vec4 returnValue = vec4(0);
	vec2 newTexCoord = v_TexCoord;
	
	
	returnValue = texture(u_TexSampler, newTexCoord) + texture(u_TexSampler1, newTexCoord);
	return returnValue;
}

void main()
{
	//FragColor = Filp();
	//FragColor = Mirror();
	FragColor = garosambunhal();
	//FragColor = brick();
	//FragColor = TwoTexture();
	//FragColor = MixTexture();
	
	//FragColor = texture(u_TexSampler, v_TexCoord);
	//FragColor = vec4(1,1,1,1);
}
