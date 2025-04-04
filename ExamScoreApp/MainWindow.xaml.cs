using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamScoreApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Сделаем поля доступными через свойства
        public TextBox Task1Score => Task1ScoreField;
        public TextBox Task2Score => Task2ScoreField;
        public TextBox Task3Score => Task3ScoreField;
        public TextBox Task4Score => Task4ScoreField;
        public TextBlock ResultText => ResultTextField;

        // Обработчик клика по кнопке
        public void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значения из текстовых полей
                int task1 = int.Parse(Task1Score.Text);
                int task2 = int.Parse(Task2Score.Text);
                int task3 = int.Parse(Task3Score.Text);
                int task4 = int.Parse(Task4Score.Text);

                // Проверяем, что все значения находятся в допустимом диапазоне
                if (task1 < 0 || task1 > 10 || task2 < 0 || task2 > 50 || task3 < 0 || task3 > 30 || task4 < 0 || task4 > 10)
                {
                    ResultText.Text = "Введите корректные значения для каждого задания.";
                    return;
                }

                // Вычисляем общий балл
                int totalScore = task1 + task2 + task3 + task4;
                string grade = GetGrade(totalScore);

                // Отображаем результат
                ResultText.Text = $"Сумма баллов: {totalScore}\nОценка: {grade}";
            }
            catch (FormatException)
            {
                // Если не удается преобразовать значение в число, показываем ошибку
                ResultText.Text = "Пожалуйста, введите числа.";
            }
            catch (Exception)
            {
                // Обработка других неожиданных ошибок
                ResultText.Text = "Произошла ошибка. Пожалуйста, попробуйте снова.";
            }
        }


        // Метод для получения оценки по баллам
        public string GetGrade(int totalScore)
        {
            if (totalScore >= 70) return "5 (отлично)";
            if (totalScore >= 40) return "4 (хорошо)";
            if (totalScore >= 20) return "3 (удовлетворительно)";
            return "2 (неудовлетворительно)";
        }
    }
}
