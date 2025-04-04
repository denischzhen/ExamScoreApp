using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamScoreApp;

namespace ExamScoreApp.Tests
{
    [TestClass]
    public class MainWindowTests
    {
        private MainWindow _window;

        [TestInitialize]
        public void Setup()
        {
            // Инициализация окна перед каждым тестом
            _window = new MainWindow();
        }

        // 1. Тест с валидными данными
        [TestMethod]
        public void CalculateButton_ValidInput_ShouldDisplayCorrectResult()
        {
            // Arrange
            _window.Task1Score.Text = "8";
            _window.Task2Score.Text = "40";
            _window.Task3Score.Text = "20";
            _window.Task4Score.Text = "8";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Сумма баллов: 76\nОценка: 5 (отлично)", _window.ResultText.Text);
        }

        // 2. Тест с граничными значениями
        [TestMethod]
        public void CalculateButton_MaxInput_ShouldDisplayCorrectResult()
        {
            // Arrange
            _window.Task1Score.Text = "10";
            _window.Task2Score.Text = "50";
            _window.Task3Score.Text = "30";
            _window.Task4Score.Text = "10";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Сумма баллов: 100\nОценка: 5 (отлично)", _window.ResultText.Text);
        }

        // 3. Тест с минимальными значениями
        [TestMethod]
        public void CalculateButton_MinInput_ShouldDisplayCorrectResult()
        {
            // Arrange
            _window.Task1Score.Text = "0";
            _window.Task2Score.Text = "0";
            _window.Task3Score.Text = "0";
            _window.Task4Score.Text = "0";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Сумма баллов: 0\nОценка: 2 (неудовлетворительно)", _window.ResultText.Text);
        }

        // 4. Тест с некорректными данными (текст вместо чисел)
        [TestMethod]
        public void CalculateButton_InvalidInput_ShouldDisplayErrorMessage()
        {
            // Arrange
            _window.Task1Score.Text = "abc";
            _window.Task2Score.Text = "xyz";
            _window.Task3Score.Text = "qwerty";
            _window.Task4Score.Text = "123a";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Пожалуйста, введите числа.", _window.ResultText.Text);
        }

        // 5. Тест с выходом за пределы диапазона для каждого задания
        [TestMethod]
        public void CalculateButton_OutOfRangeInput_ShouldDisplayErrorMessage()
        {
            // Arrange
            _window.Task1Score.Text = "11";   // Invalid
            _window.Task2Score.Text = "-1";   // Invalid
            _window.Task3Score.Text = "31";   // Invalid
            _window.Task4Score.Text = "15";   // Invalid

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Введите корректные значения для каждого задания.", _window.ResultText.Text);
        }

        // 6. Тест с корректными данными, но с разными оценками
        [TestMethod]
        public void CalculateButton_MixedInput_ShouldDisplayCorrectResult()
        {
            // Arrange
            _window.Task1Score.Text = "5";
            _window.Task2Score.Text = "30";
            _window.Task3Score.Text = "20";
            _window.Task4Score.Text = "5";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Сумма баллов: 60\nОценка: 4 (хорошо)", _window.ResultText.Text);
        }

        // 7. Тест с суммой, соответствующей оценке "3"
        [TestMethod]
        public void CalculateButton_ScoreForGrade3_ShouldDisplayCorrectResult()
        {
            // Arrange
            _window.Task1Score.Text = "5";
            _window.Task2Score.Text = "10";
            _window.Task3Score.Text = "3";
            _window.Task4Score.Text = "2";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Сумма баллов: 20\nОценка: 3 (удовлетворительно)", _window.ResultText.Text);
        }

        // 8. Тест с пустыми полями
        [TestMethod]
        public void CalculateButton_EmptyFields_ShouldDisplayErrorMessage()
        {
            // Arrange
            _window.Task1Score.Text = "";
            _window.Task2Score.Text = "";
            _window.Task3Score.Text = "";
            _window.Task4Score.Text = "";

            // Act
            _window.CalculateButton_Click(null, null);

            // Assert
            Assert.AreEqual("Пожалуйста, введите числа.", _window.ResultText.Text);
        }
    }
}

