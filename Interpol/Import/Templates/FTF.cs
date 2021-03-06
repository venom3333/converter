﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZI.Import.Mapping;

namespace SZI.Import.Templates
{
    public class FTF : Template
    {
        public FTF()
        {
            /// Основная таблица
            MainTableRow = new RowItem
            {
                TableName = "public.liczo",
                RowTemplate = new List<ColumnItem>
            {
                //////////////// Из файла ////////////////
                // 1. Фамилия_ru (для сравнения на дубль)
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Фамилия_ru",
                    TableColumnName = "familiya_ru",
                    RawValue = string.Empty,
                    ForCompare = true
                },

                // 2. Имя_ru (для сравнения на дубль)
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Имя_ru",
                    TableColumnName = "imya_ru",
                    RawValue = string.Empty,
                    ForCompare = true
                },

                // 3. Фамилия_en
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Фамилия_en",
                    TableColumnName = "familiya_en",
                    RawValue = string.Empty
                },

                // 4. Имя_en
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Имя_en",
                    TableColumnName = "imya_en",
                    RawValue = string.Empty
                },

                // 5. Дата рождения (для сравнения на дубль)
                new ColumnItem
                {
                    ColumnType = DataType.Date,
                    FileColumnName = "Дата рождения",
                    TableColumnName = "data_rozhdeniya",
                    RawValue = string.Empty,
                    ForCompare = true
                },

                // 6. Место рождения
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Место рождения",
                    TableColumnName = "mesto_rozhdeniya_text_en",
                    RawValue = string.Empty
                },

                // 7. Страна инициатор розыска
                new ColumnItem
                {
                    ColumnType = DataType.PlainText,
                    FileColumnName = "Страна инициатор розыска",
                    TableColumnName = "dopolnitelnaya_informacziya_en",
                    RawValue = "Search initiator: "
                },

                //////////////// С Формулой //////////////////
                // 8. Полное имя ru
                new ColumnItem
                {
                    ColumnType = DataType.FormulaText,
                    TableColumnName = "fullname_ru",
                    RawValue = string.Empty,
                    ColumnFormula = new Formula
                    {
                        Operator = FormulaOperator.concat,
                        Separator = new string[] {" "},
                        Fields = new List<string>
                        {
                            "Фамилия_ru",
                            "Имя_ru",
                        }
                    }
                },

                // 9. Полное имя en
                new ColumnItem
                {
                    ColumnType = DataType.FormulaText,
                    TableColumnName = "fullname_en",
                    RawValue = string.Empty,
                    ColumnFormula = new Formula
                    {
                        Operator = FormulaOperator.concat,
                        Separator = new string[] {" "},
                        Fields = new List<string>
                        {
                            "Фамилия_en",
                            "Имя_en",
                        }
                    }
                },

                // 10. ID инициатора розыска из словаря (Генеральный секретариат Интерпола (ГС Интерпол))
                new ColumnItem
                {
                    ColumnType = DataType.Dictionary,
                    DictionaryTableName = "objectsource",
                    DictionaryColumnName = "name_ru",
                    TableColumnName = "objectsource_id",
                    RawValue = "Генеральный секретариат Интерпола (ГС Интерпол)"
                },

                // 11. Список "ИТБ"
                new ColumnItem
                {
                    ColumnType = DataType.IdReference,
                    TableColumnName = "belongs_to_id",
                    RawValue = "2"
                },

                // 12. dtype = "Liczo"
                new ColumnItem
                {
                    ColumnType = DataType.ExactText,
                    TableColumnName = "dtype",
                    RawValue = "Liczo"
                },

                // 13. Категория = "Террористы"
                new ColumnItem
                {
                    ColumnType = DataType.IdReference,
                    TableColumnName = "kategoriya_licza_id",
                    RawValue = "1"
                },

                // 14. objectstate = "PUBLISHED"
                new ColumnItem
                {
                    ColumnType = DataType.ExactText,
                    TableColumnName = "objectstate",
                    RawValue = "PUBLISHED"
                }
            }
            };

            /// Связанные таблицы
            AdditionalTablesRows = new List<RowItem>();

            // basis_for_inclusion (розыск по линии интерпола) 
            AdditionalTablesRows.Add(new RowItem
            {
                TableName = "public.basis_for_inclusion",
                RowTemplate = new List<ColumnItem>
                {
                    // 1. target_type
                new ColumnItem
                {
                    ColumnType = DataType.ExactText,
                    TableColumnName = "target_type",
                    RawValue = "liczo"
                },

                // 2. target_id
                new ColumnItem
                {
                    ColumnType = DataType.MainObjectId,
                    TableColumnName = "target_id"
                },

                // 3. dictionary_item
                //new ColumnItem
                //{
                //    ColumnType = DataType.IdReference,
                //    TableColumnName = "dictionaryitem_id",
                //    RawValue = "14"
                //}

                 // 3. dictionary_item
                new ColumnItem
                {
                    ColumnType = DataType.Dictionary,
                    DictionaryDType = "Basis_for_inclusion",
                    TableColumnName = "dictionaryitem_id",
                    RawValue = "Розыск по линии Интерпола"
                }
                }
            });
        }
    }
}
