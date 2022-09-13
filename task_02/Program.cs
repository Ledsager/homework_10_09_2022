// В двумерном массиве целых чисел. Удалить строку и столбец, 
// на пересечении которых расположен наименьший элемент.

void PrintArray(int[,] matr)//вывод матрицы на экран
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} ");
        }
        Console.WriteLine();
    }
}

void FillArray(int[,] matr)//заполнение матрицы случайными числами
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);//[1; 10)
        }
    }
}

int[] FindMinIndex(int[,] arrayA)// поиск индекса элемента с мин значением
{
    int[] index = new int[2];
    int min = arrayA[0, 0];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayA.GetLength(1); j++)
        {
            if (min > arrayA[i, j])
            {
                min = arrayA[i, j];
                //Console.WriteLine(min+" ",i+" ",j);
                index[0] = i;
                index[1] = j;
            }
        }
    }
    return index;
}

int[,] DelPozitionMinElement(int[,] arrayA, int[] pozitionmin)// поиск индекса элемента с мин значением
{
    int[,] delarrayindex = new int[arrayA.GetLength(0) - 1, arrayA.GetLength(1) - 1];
    for (int i = 0; i < arrayA.GetLength(0) - 1; i++)
    {
        if (i != pozitionmin[0])
        {
            for (int j = 0; j < arrayA.GetLength(1) - 1; j++)
            {
                if (j != pozitionmin[1])
                    delarrayindex[i, j] = arrayA[i, j];
                else    
                    delarrayindex[i,j]=arrayA[i+1,j];
            }
        }
        else
        {
            for (int j = 0,k=0; j < arrayA.GetLength(1) - 1; j++)
            {
                if (j != pozitionmin[1])
                    delarrayindex[i, j] = arrayA[i+1, j];
                //Console.WriteLine(min+" ",i+" ",j);
                else    
                    delarrayindex[i,j]=arrayA[i+1,j+1];
            }
            
        }
    }
    return delarrayindex;
}


int[,] InputMatrix() // Ввод матриц размерностью [x,y]
{
    Console.WriteLine("ВВедите размерность матрицы matrix[x,y]");
    int x;
    Console.WriteLine("Input x: ");
    while (!int.TryParse(Console.ReadLine(), out x))//проверка что вводится число
        Console.Write("Неверный ввод! \nВведите значение снова : ");
    int y;
    Console.WriteLine("Input y: ");
    while (!int.TryParse(Console.ReadLine(), out y))//проверка что вводится число
        Console.Write("Неверный ввод! \nВведите значение снова : ");
    int[,] matrix = new int[x, y];
    FillArray(matrix);
    PrintArray(matrix);
    return matrix;
}

int[,] arrayA = InputMatrix();

int[] pozition = FindMinIndex(arrayA);
Console.WriteLine($"позиция минимального элемента [{pozition[0] + 1},{pozition[1] + 1}]");
PrintArray(DelPozitionMinElement(arrayA, pozition));
