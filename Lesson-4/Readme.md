# Урок 4 - Фальшивая авторизация

## Frontend

```xaml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MyApp.View3">
    <ContentPage.Content>
        <StackLayout VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand">
            <!-- Entry - поле для ввода. Placeholder - подсказка -->
            <Entry x:Name="l" Text="pavlenkocraft@gmail.com" Placeholder="Введите логин"></Entry>
            <!-- IsPassword превращает наш текст в точки -->
            <Entry x:Name="p" IsPassword="true" Text="qweqweqwe" Placeholder="Введите пароль"></Entry>
            <Button Text="Логин" Clicked ="Button_Clicked"></Button>
            <Label Text="Hello Xamarin.Forms!" x:Name="autt" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

## Backend

```cs
		// auth - название функции, которую мы будем вызывать
        // void - говорит о том, что функция ничего не возвращает
        // Принимает в себя два стринга
        void auth ( string login, string password )
        {
            // Если логин и пароль нужные, то выполнится первая часть кода
            // Если нет, то та, которая идет после else
            // && - логическое или
            if ( login == "admin" && password == "admin" )
            {
                // autt указан в Label в поле x:Name. Этот Label инициализирован в файле View3.xaml
                autt.Text = "It's alright!!!";
            }
            else
            {
                autt.Text = "LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSER";
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
			// Вызываем нашу функцию
            // l и p указаны в Entry в поле x:Name. Эти Entry инициализированы в файле View3.xaml
            auth(l.Text, p.Text);
        }
```
