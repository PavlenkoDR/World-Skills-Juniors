# Урок 8 - База данных в FireBase, или запись легче считывания

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

Необходимо установить Xamarin.Firebase.Fatabase. Делается это по аналогии 
с установкой Xamarin.Firebase.Auth из 7 урока.

Усовершенствуем функцию регистрации ```RegsiterWithEmailPassword( ... )```. Теперь она заодно будет писать данные в базу.
Функция находится в файле ```FirebaseAuthenticator.cs```

```cs
public async Task<string> RegsiterWithEmailPassword(string email, string password, string name, string secondName)
{
    var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
    var token = await user.User.GetIdTokenAsync(false);

    // Хранит в себе ссылку на базу
    FirebaseDatabase firebaseDatabase;

    // Хранит в себе ссылку на таблицу
    DatabaseReference databaseReference;

    // Будет использоваться для хранения промежуточных таблиц
    DatabaseReference child;

    try
    {
        // Получаем нашу базу
        firebaseDatabase = FirebaseDatabase.GetInstance("https://worldskills-f19d1.firebaseio.com/");
    }
    catch
    {
        throw new ArgumentException("GetInstance error");
    }

    try
    {
        // Получаем таблицу "worldskills-f19d1"
        databaseReference = firebaseDatabase.GetReference("worldskills-f19d1");
    }
    catch
    {
        throw new ArgumentException("GetReference error");
    }

    string tableName = "";

    try
    {
        // Получаем таблицу нашего нового юзера
        tableName = email.Replace('@', 'a').Replace('.', 'b');
        child = databaseReference.Child(tableName);
        // Записываем данные в базу
        await child.Child("Email").SetValueAsync(email);
        await child.Child("Name").SetValueAsync(name);
        await child.Child("SecondName").SetValueAsync(secondName);
    }
    catch
    {
        throw new ArgumentException("Add data error");
    }
    return tableName;
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
