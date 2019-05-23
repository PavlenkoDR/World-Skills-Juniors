# Урок 11 - Кастомное всплывающее окно

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

Применяем ContentView

## .xaml

```xml
<AbsoluteLayout Padding="0" HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand">
    <StackLayout AbsoluteLayout.LayoutBounds="0, 0, 1, 1" AbsoluteLayout.LayoutFlags="All">
        <!-- Тут элементы основного окна -->
    </StackLayout>
    <!-- Всплывающее окно -->
    <ContentView BackgroundColor="#C0808080" x:Name="popupLoginView" Padding="10, 0" IsVisible="false" AbsoluteLayout.LayoutBounds="0, 0, 1, 1" AbsoluteLayout.LayoutFlags="All">
        <StackLayout VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand">
            <StackLayout Orientation="Vertical" BackgroundColor="White" VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand">
                <StackLayout Orientation="Vertical" BackgroundColor="White">
                    <!-- Тут элементы всплывающего окна -->
                </StackLayout>
            </StackLayout>
            <!-- Обработчик тапов -->
            <StackLayout.GestureRecognizers>
                <TapGestureRecognizer Tapped="TapGestureRecognizer_Tapped"></TapGestureRecognizer>
            </StackLayout.GestureRecognizers>
        </StackLayout>
    </ContentView>
</AbsoluteLayout>
```

## .xaml.cs

```cs
private void Button_Clicked(object sender, EventArgs e)
{
    // popupLoginView - имя в xaml
    popupLoginView.IsVisible = true;
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
