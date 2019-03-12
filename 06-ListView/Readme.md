# Урок 5 - ListView

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

```ListView``` - список, в котором можно хранить кнопки с лейблами, картинки с описанием или другие различные сочетания контента.
Все задается по единому шаблону. Далее объяснение на примере кода.

## Frontend

```xaml
<ListView x:Name="listView" HasUnevenRows="True"  SelectionMode="None">
    <ListView.ItemTemplate>
        <DataTemplate>
            <ViewCell>
                <StackLayout Orientation="Horizontal" Padding="20">
                    <Image Source="{Binding icon}"></Image>
                    <StackLayout Orientation="Vertical">
                        <Label Text="{Binding title}" FontSize="Large" TextColor="Black"></Label>
                        <Label Text="{Binding description}" FontSize="Medium" TextColor="Gray"></Label>
                    </StackLayout>
                </StackLayout>
            </ViewCell>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
```

```HasUnevenRows``` - параметр, который говорит о том, будет ли у нас автоматическое выравнивание.
То есть может быть случай, когда мы добавляем несколько строк текста подряд, и у нас он не влазит в нашу ячейку.
Этот параметр нас спасет.

```SelectionMode``` - параметр, который говорит о том, выделится ли у нас строка, на которую мы кликнули.

```ListView.ItemTemplate``` - тут мы обращаемся к полю ItemTemplate в элементе ListView.
Это поле будет хранить в себе шаблон, по которому будут строиться наши строки

```DataTemplate``` - собственно шаблон, который нужно заполнить.

```ViewCell``` - вид показываемой ячейки. В данном случае это кастомная ячейка, которую мы формируем как хотим.
Советую использовать ее. Также, для примера, еще есть TextCell, ImageCell  и тп.
Внуть кладется макет того, как будет вышлядить содержимое.

## Backend

```cs
public class MenuItem
{
    public int Id { get; set; }
    public string icon { get; set; }
    public string title { get; set; }
    public string description { get; set; }
}
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class View1 : ContentPage
{
    public View1 ()
    {
        InitializeComponent(); // ПИСАТЬ КОД ТОЛЬКО ПОСЛЕ ЭТОЙ ФУНКЦИИ
        List<MenuItem> menuItemArray = new List<MenuItem>
        {   // Тут мы заполняем массив
            new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
            new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
            new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
            new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
            new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
            new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
            new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
            new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
            new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
            new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
            new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
            new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
        };
        listView.ItemsSource = menuItemArray; // Кладем элементы в ListView
    }
}
```

```List<MenuItem> menuItemArray``` - по сути массив, который хранит в себе ячейки типа MenuItem.

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
