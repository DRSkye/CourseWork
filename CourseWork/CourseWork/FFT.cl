struct Complex {
    int real;
    int unreal;
};

__kernel void FFT(__global short * dataMas, __global short * NMas, __global short * LenMas)
	{
	 int i = get_global_id(0);
	 dataMas[i] = 2 * dataMas[i];
	}
