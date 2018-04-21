struct Complex {
    int real;
    int unreal;
};

__kernel void FFT(__global int16_t * v1, __global int16_t * v2)
	{
	 int i = get_global_id(0);
	 v1[i] = v1[i] + v2[i];
	}
