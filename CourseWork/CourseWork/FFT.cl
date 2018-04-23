__kernel void fFT(__global short* dataMas, __global short* Pow, __global int* LenMas, __global float* resultMas)
{
	int id = get_global_id(0);
	
	for (int i = id * 30000; i < (id + 1)* 30000; i++)
	{
		resultMas[i] = 1;
	}
}
