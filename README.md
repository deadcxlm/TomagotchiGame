Описание проекта:
Данный проект реализован в соответствии с паттерном Model-View-Controller (MVC).

Структура проекта:
- Models:
  В этой директории находится интерфейс ITomagotchi, определяющий основные контракты для взаимодействия с тамагочи, а также класс Tomagotchi, который реализует этот интерфейс.
  Класс TomagotchiModel представляет модель, описывающую питомца, используемую для его создания, а также класс состояний питомца.

- Controllers:
  Этот раздел содержит реализацию связи между представлением и бизнес-логикой (моделью).

- Views:
  В данной директории реализован слой представления, использующий DTO для передачи данных из модели для обновления представления.