namespace BusDep.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    /// <summary>
    /// Enum TypeMapper
    /// </summary>
    public enum TypeMapper
    {
        IgnoreCaseSensitive,
        None
    }
    /// <summary>
    /// Enum ModeExcludeWord
    /// </summary>
    public enum ModeExcludeWord
    {
        Source,
        Target,
        All
    }

    /// <summary>
    /// Extension class Mapper
    /// </summary>
    public static class Mapper
    {
        #region metodos
        public static T MapperClass<T>(this object source)
            where T : new()
        {
            return MapperClass(source, new T());
        }

        public static T MapperClass<T>(this object source, T target)
            where T : new()
        {
            return MapperClass(source, target, TypeMapper.None);
        }

        public static T MapperClass<T>(this object source, TypeMapper typeMapper)
            where T : new()
        {
            return MapperClass(source, new T(), typeMapper);
        }

        public static T MapperClass<T>(this object source, T target, TypeMapper typeMapper)
            where T : new()
        {
            return MapperClass(source, target, typeMapper, "");
        }

        public static T MapperClass<T>(this object source, TypeMapper typeMapper, params string[] excludeWord)
            where T : new()
        {
            return MapperClass(source, new T(), typeMapper, excludeWord);
        }

        public static T MapperClass<T>(this object source, T target, TypeMapper typeMapper, params string[] excludeWord)
            where T : new()
        {
            return MapperClass(source, target, typeMapper, ModeExcludeWord.All, excludeWord);
        }

        public static T MapperClass<T>(this object source, TypeMapper typeMapper, ModeExcludeWord modeExcludeWord, params string[] excludeWord)
            where T : new()
        {
            return MapperClass(source, new T(), typeMapper, modeExcludeWord, excludeWord);
        }

        public static T MapperClass<T>(this object source, T target, TypeMapper typeMapper, ModeExcludeWord modeExcludeWord, params string[] excludeWord)
            where T : new()
        {

            try
            {

                var liPropertyInfoSource = source.GetType().GetProperties();
                var liPropertyInfoTarget = target.GetType().GetProperties();
                foreach (var sourcePropertyInfo in liPropertyInfoSource)
                {
                    string sourcePropertyName;
                    switch (modeExcludeWord)
                    {
                        case ModeExcludeWord.All:
                        case ModeExcludeWord.Source:
                            sourcePropertyName = FillNameProperty(sourcePropertyInfo.Name, excludeWord);
                            break;
                        default:
                            sourcePropertyName = sourcePropertyInfo.Name;
                            break;
                    }

                    foreach (var targetPropertyInfo in liPropertyInfoTarget)
                    {
                        string targetPropertyName;
                        switch (modeExcludeWord)
                        {
                            case ModeExcludeWord.All:
                            case ModeExcludeWord.Target:
                                targetPropertyName = FillNameProperty(targetPropertyInfo.Name, excludeWord);
                                break;
                            default:
                                targetPropertyName = targetPropertyInfo.Name;
                                break;
                        }
                        bool isEqualProperty;
                        if (typeMapper.Equals(TypeMapper.IgnoreCaseSensitive))
                        {
                            isEqualProperty = targetPropertyName.ToUpper(CultureInfo.InvariantCulture).Equals(sourcePropertyName.ToUpper(CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            isEqualProperty = targetPropertyName.Equals(sourcePropertyName);
                        }

                        if (isEqualProperty)
                        {
                            var valueSource = sourcePropertyInfo.GetValue(source, null);
                            try
                            {
                                targetPropertyInfo.SetValue(
                                    target,
                                    Convert.ChangeType(
                                        valueSource,
                                        sourcePropertyInfo.PropertyType,
                                        CultureInfo.InvariantCulture),
                                    null);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    targetPropertyInfo.SetValue(target, valueSource, null);
                                }
                                catch
                                {

                                    if (targetPropertyInfo.ToString().Contains("String"))
                                    {
                                        targetPropertyInfo.SetValue(target, valueSource.ToString(), null);
                                    }

                                }
                            }
                            break;
                        }
                    }
                }
                return target; 
            }
            catch { return target; }
            
        }

        private static string FillNameProperty(string name, IEnumerable<string> excludeWord)
        {
            return excludeWord.Aggregate(name, (current, s) => !string.IsNullOrEmpty(s) ? current.Replace(s, "") : current);
        }

        public static IEnumerable<T> MapperEnumerable<T>(this IEnumerable<object> source, TypeMapper typeMapper, ModeExcludeWord modeExcludeWord, params string[] excludeWord)
            where T : new()
        {
            return (from r in source select r.MapperClass<T>(typeMapper, modeExcludeWord, excludeWord));
        }

        public static IEnumerable<T> MapperEnumerable<T>(this IEnumerable<object> source, TypeMapper typeMapper, ModeExcludeWord modeExcludeWord)
            where T : new()
        {
            return MapperEnumerable<T>(source, typeMapper, modeExcludeWord, "");
        }

        public static IEnumerable<T> MapperEnumerable<T>(this IEnumerable<object> source, TypeMapper typeMapper)
            where T : new()
        {
            return MapperEnumerable<T>(source, typeMapper, ModeExcludeWord.All);
        }

        public static IEnumerable<T> MapperEnumerable<T>(this IEnumerable<object> source)
            where T : new()
        {
            return MapperEnumerable<T>(source, TypeMapper.None);
        }
        #endregion
    }
}