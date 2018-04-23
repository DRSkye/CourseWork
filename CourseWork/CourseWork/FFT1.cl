//Получаем новый индекс
unsigned int NewIndex(unsigned int num, int powOfTwo)
{
	unsigned int i = 1;
	unsigned int help=0;

	//в 2 виде
    while (num > 0)
    {
        help += i * (num % 2);
        i*=10;
        num/=2;
    }

	//Получаем новое число
	unsigned int newNum = 0;
	i = powOfTwo - GetCount(help); //недостоющих разрядов
	while (help > 0)
	{
		newNum = newNum * 2 + (help % 10);
		help /= 10;
	}
	while (i > 0)
	{
		newNum *= 2;
		i--;
	}

    return newNum;
}

//Количество разрядов в числе
int GetCount(unsigned int len)
{
	int count = 0;
	while (len != 0)
	{
		len /= 10;
		count++;
	}
	return count;
}

//Получаем нужный массив
short* Split(short *Origin, int i, int length) //Выделяем наш массив
{
    short helpMas[length];
	int count=0;
    for (int j=(i*length);j<(i+1)*length;j++)
	{
		helpMas[count] = Origin[j];
		count++;
	}
    return helpMas;
}

//Подготовка массива
short* FirstPart(short *Origin, int length, short pow)
{
	short helpMas[length];
	for (unsigned int j = 0; j < length; j++)
		helpMas[newIndex(j, pow)] = Origin[j];
	return helpMas;
}

//Экпонента
float Exp(float num)
{
	float help = num;
	float exp = 1;
	int n = 1;
	for (short i = 2; i < 13; i++)
	{
		exp += help / n;
		help *= num;
		n *= i;
	}
	return exp;
}

//Вычисляем коэф W(k,N) = exp(-i * 2kП/N) ; экспанента от комплексного числа = произведению экспонент (в нашем случае - мнимой части)
float GetCoef(int count, int num)
{
	float Pi = 3.141592653589793238462643;
	float number;
	number = Exp(-2*num*Pi/count);
	return number;
}

//Собираем ответ
float* GetResult(short *Data, int length, short pow)
{
	int numCount = 2; //Число элементов, с которыми работаем
	float resultMas[length];

	for (int i = 0; i < length; i++)
		resultMas[i] = (float)Data[i];

	//Шаги цикла
	while (pow != 0)
	{
		//Работаем с группами
		for (int group = 0; group < length; group += numCount)
		{
			for (int i = group; i < group + numCount / 2; i++)
			{
				float x = resultMas[i]; //Исходные числа
				float y = resultMas[i + numCount / 2];
				float coef = GetCoef(numCount, i - group); //Вычисляем коэф

				resultMas[i] = x + y * coef;
				resultMas[i + numCount / 2] = x - y * coef;
			}
		}

		numCount *= 2;
		pow--;
	}
	return resultMas;
}

__kernel void Start(__global short* dataMas, __global short* Pow, __global int* LenMas, __global float* resultMas)
{
	//Инициализация
	int id = get_global_id(0); //Получаем номер потока- номер звуковой дорожки
	int length = LenMas[0]; //Длина дорожки
	short pow = Pow[0]; //Степень двойки
	//short mainMas[length]; //Основной
	short mainMas[length] = Split(dataMas, id, length);
	//short helpMas[length]; //Вспомогательный
	//mainMas = Split(dataMas, i, length); //Получаем нужную дорожку
	
	//Подготовка массива
	mainMas = FirstPart(mainMas, length, pow);
	/*for (unsigned int j=0; j < length; j++)
		helpMas[newIndex(j, pow)] = mainMas[j];*/
	
	//Подсчёт массива
	float *result = GetResult(mainMas, length, pow);
	
	//Запись полученных данных обратно
	int count = 1;
	for (int i = id * 30000; i < (id + 1)* 30000; i++)
	{
		resultMas[i] = result[count];
		count++;
	}
}
