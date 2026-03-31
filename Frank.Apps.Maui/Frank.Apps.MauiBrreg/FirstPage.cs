namespace Frank.Apps.MauiBrreg
{
    public class FirstPage : ContentPage
    {
        public FirstPage()
        {
            Content = new StackLayout { Children = { new Label { Text = "Hello World!" } } };
        }
    }
}