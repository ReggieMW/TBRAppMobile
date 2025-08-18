# 📚 TBRAppMobile

A cross-platform **.NET MAUI app** for tracking your personal library
and organizing books into different reading statuses:\
*Want to Read, Currently Reading, Read, Did Not Finish (DNF), and My
Canon (favorites).*

------------------------------------------------------------------------

## 🚀 Features

-   📖 **Book Management**\
    Add, view, edit, and delete books with details like Title, Author,
    Subject, Vibe, Source, Pages, and Cover Image.

-   🔍 **Smart Search & Suggestions**\
    Autocomplete for Authors, Subjects, Vibes, and Sources with live
    suggestions.

-   🗂 **Organized Lists**\
    Separate pages for:

    -   TBR (To Be Read)\
    -   Currently Reading\
    -   Read\
    -   DNF (Did Not Finish)\
    -   My Canon (favorites list, independent of status)

-   🌐 **Google Books Integration**\
    Search and import book data directly from Google Books API.

-   📱 **Cross-Platform**\
    Works on Android, iOS, Windows, and MacCatalyst with a unified .NET
    MAUI codebase.

------------------------------------------------------------------------

## 📷 Screenshots

*(Optional -- add screenshots of your app here)*

------------------------------------------------------------------------

## 🛠️ Tech Stack

-   [.NET MAUI](https://learn.microsoft.com/dotnet/maui) (C#)\
-   SQLite for persistent storage\
-   MVVM pattern with `INotifyPropertyChanged`\
-   Shell-based navigation\
-   Google Books API

------------------------------------------------------------------------

## 📦 Installation

1.  Clone the repo:

    ``` bash
    git clone https://github.com/your-username/TBRAppMobile.git
    ```

2.  Open the project in **Visual Studio 2022+** with .NET MAUI workload
    installed.

3.  Restore dependencies:

    ``` bash
    dotnet restore
    ```

4.  Run the project on your desired platform (Android, iOS, Windows,
    Mac).

------------------------------------------------------------------------

## 📖 Usage

-   Launch the app → Starts on **Currently Reading** list.\
-   Add books via the **Add Book Page**:
    -   Enter details manually or fetch from Google Books API.
    -   Choose or upload a book cover.\
-   Tap a book → Opens **BookViewPage** with full details.\
-   Update status or toggle Canon inclusion.\
-   Navigate between lists using the bottom tab navigation.

------------------------------------------------------------------------

## 🧩 Roadmap

-   [ ] Sorting and filtering options on each list page.\
-   [ ] User-created custom lists.\
-   [ ] Cloud sync and backup.\
-   [ ] Dark mode theme.

------------------------------------------------------------------------

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!\
Fork the repo and submit a PR, or open an issue for discussion.

------------------------------------------------------------------------

## 📜 License

Distributed under the MIT License. See `LICENSE` for details.
