Функция: Ввод справочника Справочник кодов ОКС
Заполнение справочника кодов ОКС

@регрес
Сценарий: Первичная загрузка данных Справочник кодов ОКС
	Дано  в справочнике 'Справочник кодов ОКС' количество записей = '0' 
	Когда вводим в справочник 'Справочник кодов ОКС' запись:
			| Родитель | Код            | Полное наименование | Начало     | Конец      |
			|          | 00000000045487 | Внешний код 1       | 01.01.1900 | 01.01.2100 |
			|          | 00000000011111 | Наименование тест 1 | 01.01.1900 | 01.01.2100 |
			|          | 00000000022222 | Наименование тест 2 | 01.01.1900 | 01.01.2100 |
			|          | 00000000209118 | Внешний код 2       | 01.01.1900 | 01.01.2100 |

	Тогда в справочнике 'Справочник кодов ОКС' количество записей = '4'
