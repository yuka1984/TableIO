﻿using System.IO;
using TableIO.ModelValidators;
using TableIO.PropertyMappers;
using TableIO.RowReaders;
using TableIO.RowWriters;
using TableIO.TypeConverters;

namespace TableIO
{
    public class TableFactory
    {
        public TableReader<TModel> CreateReader<TModel>(IRowReader rowReader,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null,
            IModelValidator modelValidator = null)
            where TModel : new()
        {
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();
            modelValidator = modelValidator ?? new NullModelValidator();

            var reader = new TableReader<TModel>(rowReader, typeConverterResolver, propertyMapper, modelValidator);

            return reader;
        }

        public TableWriter<TModel> CreateWriter<TModel>(IRowWriter rowWriter,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null)
        {
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();

            return new TableWriter<TModel>(rowWriter, typeConverterResolver, propertyMapper);
        }

        public TableReader<TModel> CreateCsvReader<TModel>(TextReader textReader,
            bool hasHeader = false,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null,
            IModelValidator modelValidator = null)
            where TModel : new()
        {
            var rowReader = new CsvStreamRowReader(textReader);
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();
            modelValidator = modelValidator ?? new NullModelValidator();

            var reader = new TableReader<TModel>(rowReader, typeConverterResolver, propertyMapper, modelValidator);
            reader.HasHeader = hasHeader;

            return reader;
        }

        public TableWriter<TModel> CreateCsvWriter<TModel>(TextWriter textWriter,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null)
        {
            var rowWriter = new CsvRowWriter(textWriter);
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();

            return new TableWriter<TModel>(rowWriter, typeConverterResolver, propertyMapper);
        }

        public TableReader<TModel> CreateTsvReader<TModel>(TextReader textReader,
            bool hasHeader = false,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null,
            IModelValidator modelValidator = null)
            where TModel : new()
        {
            var rowReader = new TsvStreamRowReader(textReader);
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();
            modelValidator = modelValidator ?? new NullModelValidator();

            var reader = new TableReader<TModel>(rowReader, typeConverterResolver, propertyMapper, modelValidator);
            reader.HasHeader = hasHeader;

            return reader;
        }

        public TableWriter<TModel> CreateTsvWriter<TModel>(TextWriter textWriter,
            ITypeConverterResolver typeConverterResolver = null,
            IPropertyMapper propertyMapper = null)
        {
            var rowWriter = new TsvRowWriter(textWriter);
            typeConverterResolver = typeConverterResolver ?? new DefaultTypeConverterResolver<TModel>();
            propertyMapper = propertyMapper ?? new AutoIndexPropertyMapper();

            return new TableWriter<TModel>(rowWriter, typeConverterResolver, propertyMapper);
        }
    }
}
