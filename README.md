# ChessValidator

Консольное приложение для размещения шахматных фигур на доске 8×8 и проверки взаимных атак между ними. Поддерживает стандартные фигуры (король, ферзь, ладья, слон, конь) и новую фигуру - Теника (Shadow).

## Быстрый запуск

### Команды

```bash
git clone https://github.com/Konstkonst55/ChessValidator.git
cd ChessValidator
dotnet build
```

#### Запуск с файлом по умолчанию [Examples/all_attacks.txt](ChessValidator/Examples/all_attacks.txt)

```bash
dotnet run --project ChessValidator
```

#### Запуск с указанием конкретного файла

```bash
dotnet run --project ChessValidator -- Examples blocking_path.txt
```

#### Запуск из другого каталога с тестовыми данными

```bash
dotnet run --project ChessValidator -- C:\Tests board.txt
```

### Аргументы командной строки

`[папка]` - путь к папке с входным файлом (по умолчанию [Examples](ChessValidator/Examples/))

`[файл]` - имя входного файла (по умолчанию [all_attacks.txt](ChessValidator/Examples/all_attacks.txt))

### Формат входного файла

```text
king 0 0
queen 7 7
rook 0 7
bishop 7 0
knight 1 2
shadow 3 3
```

#### Формат строки

`[тип] [x] [y]`, где `x` и `y` - координаты от 0 до 7.

#### Поддерживаемые типы фигур

`king`, `queen`, `rook`, `bishop`, `knight`, `shadow`. Фигур должно быть от 2 до 10, все на разных клетках.

## Описание реализации

### Архитектура

Решение разделено на два проекта:

`ChessValidator.Shared` (Shared Project) - вся бизнес-логика, модели, парсинг и рендеринг

`ChessValidator.Console` - консольный интерфейс, пример использования

Иерархия фигур построена на абстрактном классе `Piece`, от которого наследуются все конкретные фигуры. Это позволяет единообразно проверять атаки через метод `CanAttack(target, board)`.

### Теник (Shadow)

Согласно ТЗ Теник обладает механикой оставления следов-препятствий после движения. В текущей реализации эта механика не реализована, и логика атаки Теника идентична ферзю - ортогональные и диагональные линии с блокировкой другими фигурами.

В рамках данной задачи фигуры статичны, ходы не совершаются - проверяются только атаки из начальной расстановки. Механика теней имеет смысл только в динамике игры, когда фигуры перемещаются.

### Готовность к расширению

#### Новые фигуры

Достаточно создать класс, унаследованный от `Piece`, переопределить `Symbol` и `CanAttack`, и добавить его в `switch` парсера.

#### Новые правила

Методы `IsOrthogonalAttack`, `IsDiagonalAttack`, `IsPathClear` в базовом классе переиспользуемы.

#### Новые методы отрисовки

Интерфейсы `IBoardParser`, `IBoardRenderer`, `IAttackDetector` позволяют подменить реализацию без изменения ядра.

## Пример работы

### Входной файл [all_attacks.txt](ChessValidator/Examples/all_attacks.txt):

```text
king 0 0
queen 7 7
rook 0 7
bishop 7 0
knight 1 2
shadow 3 3
```

### Вывод в консоль

```text
Состояние доски:
R . . . . . . Q
. . . . . . . .
. . . . . . . .
. . . . . . . .
. . . S . . . .
. N . . . . . .
. . . . . . . .
K . . . . . . B

Список атак:
Queen (7,7) -> Rook (0,7)
Queen (7,7) -> Bishop (7,0)
Queen (7,7) -> Shadow (3,3)
Rook (0,7) -> King (0,0)
Rook (0,7) -> Queen (7,7)
Bishop (7,0) -> Rook (0,7)
Knight (1,2) -> King (0,0)
Knight (1,2) -> Shadow (3,3)
Shadow (3,3) -> King (0,0)
Shadow (3,3) -> Queen (7,7)
```

## Структура проекта

```text
ChessValidator/
├── ChessValidator.sln
├── ChessValidator.Console/          
│   ├── Program.cs
│   └── Examples/                   
│       ├── all_attacks.txt
│       ├── blocking_path.txt
│       ├── board_size_validation.txt
│       ├── duplicate_position_validation.txt
│       ├── incorrect_format_validation.txt
│       ├── incorrect_piece_validation.txt
│       ├── too_few_pieces.txt
│       └── too_many_pieces.txt
└── ChessValidator.Shared/           
    ├── Exceptions/
    │   ├── ChessValidationException.cs
    │   ├── DuplicatePositionException.cs
    │   ├── InvalidPieceCountException.cs
    │   └── InvalidPositionException.cs
    ├── Models/
    │   ├── ChessBoard.cs
    │   └── Position.cs
    ├── Pieces/
    │   ├── Piece.cs                 
    │   ├── King.cs
    │   ├── Queen.cs
    │   ├── Rook.cs
    │   ├── Bishop.cs
    │   ├── Knight.cs
    │   └── Shadow.cs
    └── Services/
        ├── Logic/
        │   ├── IAttackDetector.cs
        │   └── AttackDetector.cs
        ├── Parsing/
        │   ├── IBoardParser.cs
        │   └── BoardParser.cs
        └── Rendering/
            ├── IBoardRenderer.cs
            └── BoardRenderer.cs
```