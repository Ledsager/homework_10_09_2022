// Найти произведение двух матриц

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
            matr[i, j] = new Random().Next(1, 4);//[1; 10)
        }
    }
}

int[,] MultiplicationsArray(int[,] arrayA, int[,] arrayB)//перемножение матриц 
{
    int[,] multiplicationsarray = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            multiplicationsarray[i, j] = 0;
            for (int k = 0; k < arrayA.GetLength(1); k++)
                multiplicationsarray[i, j] += arrayA[i, k] * arrayB[k, j];
        }
    }
    return multiplicationsarray;
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
Console.WriteLine("Первая матрица : ");
int[,] arrayA = InputMatrix();
Console.WriteLine("Вторая матрица : ");
int[,] arrayB = InputMatrix();
Console.WriteLine();
if (arrayA.GetLength(1) == arrayB.GetLength(0))
{
    Console.WriteLine("результирующая матрица : ");
    PrintArray(MultiplicationsArray(arrayA, arrayB));
}
else
    Console.Write("матрицы нельзя перемножить");


