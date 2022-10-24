using System;
using System.Data;
using System.IO;

namespace Libmas1
{
    public class LibMas
    {

        /// <summary>
        /// Заполнение массива случайными значениями
        /// </summary>
        /// <param name="mas">Передаваемый и возвращаемый массив</param>
        public static void ZapolnMas(ref int[,] mas)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rnd.Next(1, 20);
                }
            }
        }
        /// <summary>
        /// Очистка массива
        /// </summary>
        /// <param name="mas">Передаваемый массив</param>
        public static void OchistMas(ref int[,] mas)
        {
            mas = new int[0,0];
        }
        /// <summary>
        /// Сохраняет двумерный массив
        /// </summary>
        /// <param name="mas">Двумерный массив</param>
        /// <param name="path">Путь до файла</param>
        public static void SaveMas(int[,] mas, string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        file.WriteLine(mas[i, j]);
                    }
                }
                file.Close();
            }
        }
        /// <summary>
        /// Считывание массива из файла
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="path"></param>
        public static void UploadMas(ref int[,] mas, string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int.TryParse(reader.ReadLine(), out int row);
                int.TryParse(reader.ReadLine(), out int column);

                mas = new int[row, column];

                for (int i = 0; i < mas.GetLength(0); i++)
                {
                    for (int j = 0; j < mas.GetLength(1); j++)
                    {
                        int.TryParse(reader.ReadLine(), out int value);
                        mas[i, j] = value;
                    }
                }
                reader.Close();
            }
        }
    }

    public static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

    }
}

