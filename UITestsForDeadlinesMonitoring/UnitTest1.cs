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
            //var ExpectedText = "Попов Сергей";

            await Task.Delay(100);
            var B_Add = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "buttonAdd");
            //var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "fIOCS");

            //textbox.Text = "Попов Сергей";
            //B_Add.Command.Execute(B_Add.CommandParameter);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First(t => t.Name == "studentList");
            //var listBoxItems = listBox.GetVisualDescendants().OfType<ListBoxItem>().First();

            // var rez = listBoxItems.;
            B_Add.Command.Execute(B_Add.CommandParameter);
            Assert.True(listBox.ItemCount == 1);

            await Task.Delay(50);
        }
    }
}