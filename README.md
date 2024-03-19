Описание проекта:
Данный проект реализован в соответствии с паттерном Model-View-Controller (MVC).

Структура проекта:
- Models:
  В этой папке находится интерфейс ITomagotchi, определяющий основные контракты для взаимодействия с тамагочи, а также класс Tomagotchi, который реализует этот интерфейс.
  Класс TomagotchiModel представляет модель, описывающую питомца, используемую для его создания, а также класс состояний питомца.
  
- Views:
  В данной папке реализован слой представления, использующий DTO для передачи данных из модели для обновления представления.
  
- Controllers:
  Этот раздел содержит реализацию связи между представлением и бизнес-логикой (моделью).


