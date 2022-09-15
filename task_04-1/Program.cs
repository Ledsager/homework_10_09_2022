// Показать треугольник Паскаля *Сделать вывод в виде равнобедренного треугольника

int n = 5;
int[,] matr = new int[n, n];
const int cent = 3;

void PascalTriangle()
{
    for (int i = 0; i < n; i++)
    {
        matr[i, 0] = 1;
        matr[i, i] = 1;
    }
    for (int i = 2; i < n; i++)
    {
        for (int j = 1; j < i; j++)
        {
            matr[i, j] = matr[i - 1, j - 1] + matr[i - 1, j];
        }
    }
}

void PrintArray()//вывод матрицы на экран
{
    int shir = cent * n;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            Console.SetCursorPosition(shir, i + 1);
            if (matr[i, j] != 0)
                Console.Write($"{matr[i, j],cent}");
            shir += cent*2;
        }
        shir = cent*n - cent * (i + 1);
        Console.WriteLine();
    }
}

PascalTriangle();
PrintArray();