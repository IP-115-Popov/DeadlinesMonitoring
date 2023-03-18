using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.VisualTree;

namespace UITestsForDeadlinesMonitoring
{
    public class UnitTest1
    {
        [Fact]
        public async void buttonAdd()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            int Expected = 1;

            await Task.Delay(100);
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");
            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First(t => t.Name == "studentList");

            Assert.True(listBox.ItemCount == Expected);
            await Task.Delay(50);
        }
        [Fact]
        public async void buttonAdd1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            var ExpectedText = "Попов Сергей";

            await Task.Delay(100);
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");
            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "fIOCS");

            textbox.Text = "Попов Сергей";
            B_Add.Command.Execute(B_Add.CommandParameter);

            var textfio = mainWindow.GetVisualDescendants().OfType<TextBlock>().First(t => t.Name == "itemFIO").Text;

            Assert.True(textfio == "Попов Сергей");

            await Task.Delay(50);
        }
    }
}