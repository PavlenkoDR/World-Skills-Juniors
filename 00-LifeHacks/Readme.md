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
	image.Source = reader.Value.ToString();
	//image.Source = new Uri(reader.Value.ToString());
	//image.Source = ImageSource.FromUri(new Uri(reader.Value.ToString()));
	//image.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(reader.Value.ToString()) };
	imagesStack.Children.Add(image);
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)