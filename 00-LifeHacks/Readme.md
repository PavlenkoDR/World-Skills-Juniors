# Урок 0 - Лайфхаки

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

## 1 - Обработчик событий для любого xaml элемента на примере StackLayout

Обработчик с именем TapGestureRecognizer_Tapped, для примера. Также там есть свайпы

```xaml
<StackLayout VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand">
	<!-- Элементы -->
	<StackLayout.GestureRecognizers>
		<TapGestureRecognizer Tapped="TapGestureRecognizer_Tapped"></TapGestureRecognizer>
	</StackLayout.GestureRecognizers>
</StackLayout>
```

```cs
private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
{
	// Выполняемый код
}
```

## 2 - Добавление элементов в реальном времени

```xaml
<StackLayout x:Name="imagesStack"></StackLayout>
```

```cs
void foo()
{
	Image image = new Image();
	// 4 способа загрузить картинку из интернета
	image.Source = "image.png";
	imagesStack.Children.Add(image);
}
```

## 3 - Несколько способов задать источник для Image

```xaml
<Image x:Name="image"></Image>
```

```cs
void foo()
{
	string url = "https://pp.userapi.com/c845124/v845124849/1b527c/i9y_94keILE.jpg";
	// 4 способа загрузить картинку из интернета
	image.Source = url;
	image.Source = new Uri(url);
	image.Source = ImageSource.FromUri(new Uri(url));
	image.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(url) };
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)