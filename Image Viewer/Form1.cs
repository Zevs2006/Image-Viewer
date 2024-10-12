using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Image_Viewer
{
    public partial class Form1 : Form
    {
        private string[] imageFiles; // Массив файлов изображений
        private int currentIndex = 0; // Индекс текущего изображения
        private float zoomFactor = 1.0f; // Коэффициент масштабирования

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadFolder_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    // Получаем все изображения в выбранной папке
                    imageFiles = Directory.GetFiles(selectedPath, "*.*")
                                           .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"))
                                           .ToArray();

                    if (imageFiles.Length > 0)
                    {
                        currentIndex = 0; // Сбрасываем индекс
                        LoadImage(imageFiles[currentIndex]); // Загружаем первое изображение
                    }
                    else
                    {
                        MessageBox.Show("В выбранной папке нет изображений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void LoadImage(string filePath)
        {
            var image = Image.FromFile(filePath); // Загружаем изображение
            pictureBox.Image = image; // Устанавливаем изображение в PictureBox
            zoomFactor = 1.0f; // Сбрасываем коэффициент масштабирования
            AdjustImageSize(image); // Настраиваем размер изображения
        }

        private void AdjustImageSize(Image image)
        {
            if (image != null)
            {
                // Рассчитываем новые размеры в зависимости от коэффициента масштабирования
                int newWidth = (int)(image.Width * zoomFactor);
                int newHeight = (int)(image.Height * zoomFactor);

                // Убедитесь, что размеры больше нуля
                if (newWidth <= 0 || newHeight <= 0)
                {
                    // Если размеры некорректные, устанавливаем изображение без изменений
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Устанавливаем режим отображения
                    return;
                }

                // Устанавливаем размер в PictureBox с учётом режима отображения
                if (newWidth > pictureBox.Width || newHeight > pictureBox.Height)
                {
                    // Уменьшаем изображение, если оно больше размеров PictureBox
                    float widthRatio = (float)pictureBox.Width / image.Width;
                    float heightRatio = (float)pictureBox.Height / image.Height;
                    float minRatio = Math.Min(widthRatio, heightRatio);

                    newWidth = (int)(image.Width * minRatio);
                    newHeight = (int)(image.Height * minRatio);
                }

                // Устанавливаем новое изображение
                pictureBox.Image = new Bitmap(image, newWidth, newHeight); // Изменяем размер изображения
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Устанавливаем режим отображения
                pictureBox.Refresh(); // Обновляем PictureBox
            }
        }


        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (imageFiles != null && imageFiles.Length > 0)
            {
                currentIndex = (currentIndex + 1) % imageFiles.Length; // Переход к следующему изображению
                LoadImage(imageFiles[currentIndex]);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (imageFiles != null && imageFiles.Length > 0)
            {
                currentIndex = (currentIndex - 1 + imageFiles.Length) % imageFiles.Length; // Переход к предыдущему изображению
                LoadImage(imageFiles[currentIndex]);
            }
        }

        private void numericUpDownZoom_ValueChanged(object sender, EventArgs e)
        {
            zoomFactor = (float)numericUpDownZoom.Value; // Получаем значение масштаба
            if (pictureBox.Image != null)
            {
                AdjustImageSize(pictureBox.Image); // Изменяем размер изображения при изменении масштаба
            }
        }
    }
}
