﻿using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableIO.PropertyMappers;
using TableIO.TypeConverters;

namespace TableIO.NPOI
{
    public static class TableFactoryExtensions
    {
        //public static TableReader<TModel> CreateXlsxReader<TModel>(this TableFactory factory,
        //    IXLWorksheet worksheet, int startRowNumber, int startColumnNumber, int columnSize,
        //    bool hasHeader = false,
        //    ITypeConverterResolver typeConverterResolver = null,
        //    IPropertyMapper propertyMapper = null,
        //    IModelValidator modelValidator = null)
        //    where TModel : new()
        //{
        //    var rowReader = new XlsxRowReader(worksheet, startRowNumber, startColumnNumber, columnSize);
        //    typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
        //    propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();
        //    modelValidator = modelValidator ?? new NullModelValidator();

        //    var reader = new TableReader<TModel>(rowReader, typeConverterResolver, propertyMapper, modelValidator);
        //    reader.HasHeader = hasHeader;
        //    reader.ColumnSize = columnSize;

        //    return reader;
        //}

        public static TableWriter<TModel> CreateExcelWriter<TModel>(this TableFactory factory,
            ISheet worksheet, int startRowNumber, int startColumnNumber,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null)
        {
            var rowWriter = new ExcelRowWriter(worksheet, startRowNumber, startColumnNumber);
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();

            return new TableWriter<TModel>(rowWriter, typeConverterResolver, propertyMapper);
        }
    }
}
