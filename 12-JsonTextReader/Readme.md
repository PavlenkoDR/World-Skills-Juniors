# Урок 12 - JsonTextReader

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

## Описание некоторых TokenType в JsonTextReader

StartObject - говорит о начале объекта

EndObject - говорит о конце объекта

StartArray - говорит о начале массива

EndArray - говорит о конце массива

PropertyName - наименование некоторого поля(переменной)

String - строка

Integer - число

None - ничего не считано

Пример разбора

```
{                       	StartObject
	"dog" = "Sharik",   		PropertyName(dog) = String(Sharik)
	"catYO" = 5,        		PropertyName(catYO) = Integer(5)
	"fruits" =          		PropertyName(fruits) = 
	[                   		StartArray
		"apple",			String(apple)
		"banana",			String(banana)
		"pineapple",			String(pineapple)
		"pear"				String(pear)
	]				EndArray
}				EndObject
```

## .xaml

```xaml
<StackLayout>
    <Button HorizontalOptions="Center" VerticalOptions="Center" Text="Show Popup" Clicked="Button_Clicked"></Button>
    <!-- Тут лежат картиночки -->
    <StackLayout x:Name="imagesStack"></StackLayout>
    <Label x:Name="label1" TextColor="Black"></Label>
</StackLayout>
```

## .xaml.cs

```cs
using Newtonsoft.Json;

private async Task GetImagesFromJson(JsonTextReader reader)
{
	while (reader.ReadAsync().Result)
	{
		if (reader.Value != null)
		{
			// Вывод считанного значения, если значение есть
			label1.Text += reader.TokenType + ": " + reader.Value + "\n";
			// Так как для примера рассматривается стена ВК, то мы ищем конкретную строку
			// Которая начинается на "photo_"
			if (reader.Value.ToString().Contains("photo_"))
			{
				// После чего мы делаем считывание, там будет лежать ссылка на картинку
				await reader.ReadAsync();
				Image image = new Image();
				// 4 способа получить картинку из интернета
				image.Source = reader.Value.ToString();
				//image.Source = new Uri(reader.Value.ToString());
				//image.Source = ImageSource.FromUri(new Uri(reader.Value.ToString()));
				//image.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(reader.Value.ToString()) };
				imagesStack.Children.Add(image);
			}
		}
		else
		{
			// Вывод считанного значения, если значения нет
			label1.Text += reader.TokenType + "\n";
		}
	}
}

private async void Button_Clicked(object sender, EventArgs e)
{// Пример авторизации в vk.com через GET запрос

	using (HttpClient client = new HttpClient())
	{
		try
		{
			// Создаем реадер
			// В responseAsString лежит JSON
			JsonTextReader reader = new JsonTextReader(new StringReader(responseAsString));

			// Вызываем нашу функцию, которая вытащит картинки из реадера
			GetImagesFromJson(reader);
		}
		catch (Exception ex)
		{
			// Ошиба на случай, если упадет преобразование из JSON в VKJson
			await DisplayAlert("Иная ошибка!", ex.Message, "OK");
		}
	}
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
