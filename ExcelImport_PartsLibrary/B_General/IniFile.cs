﻿// ***********************************************************************
// Assembly         : SigmaNESTPlugin
// Author           : Anthony Roberson
// Created          : 10-12-2015
//
// Last Modified By : Anthony Roberson
// Last Modified On : 10-12-2015
// ***********************************************************************
// <copyright file="IniFile.cs" company="SigmaTEK Systems">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/// <summary>
/// The INI namespace.
/// </summary>
namespace INI
{
    /// <summary>
    /// The boolean type to be written to an ini file.
    /// </summary>
    public enum BoolStringType
    {
        StringTrueFalse,
        StringYesNo,
        CharTF,
        CharYN,
        Integer
    };

    /// <summary>
    /// Class INIFile.
    /// </summary>
    public class IniFile
    {
        Dictionary<string, Dictionary<string, string>> ini = new Dictionary<string, Dictionary<string, string>>(StringComparer.InvariantCultureIgnoreCase);
        /// <summary>
        /// The file path of the ini file.
        /// </summary>
        public string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="IniFile"/> class.
        /// </summary>
        /// <param name="filePath">The file path of the ini file.</param>
        public IniFile(string filePath)
        {
            this.path = filePath;

            if (!File.Exists(filePath))
                return;

            Load();
        }

        /// <summary>
        /// Load the INI file content
        /// </summary>
        public void Load()
        {
            var txt = File.ReadAllText(path);

            Dictionary<string, string> currentSection = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            ini[""] = currentSection;

            foreach (var l in txt.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                              .Select((t, i) => new
                              {
                                  idx = i,
                                  text = t.Trim()
                              }))
            {
                var line = l.text;

                if (line.StartsWith(";") || string.IsNullOrWhiteSpace(line))
                {
                    currentSection.Add(";" + l.idx.ToString(), line);
                    continue;
                }

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
                    ini[line.Substring(1, line.Length - 2)] = currentSection;
                    continue;
                }

                var idx = line.IndexOf("=");
                if (idx == -1)
                    currentSection[line] = "";
                else
                    currentSection[line.Substring(0, idx)] = line.Substring(idx + 1);
            }
        }

        /// <summary>
        /// Save the INI file
        /// </summary>
        public void Save()
        {
            var sb = new StringBuilder();
            foreach (var section in ini)
            {
                if (section.Key != "")
                {
                    sb.AppendFormat("[{0}]", section.Key);
                    sb.AppendLine();
                }

                foreach (var keyValue in section.Value)
                {
                    if (keyValue.Key.StartsWith(";"))
                    {
                        sb.Append(keyValue.Value);
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}", keyValue.Key, keyValue.Value);
                        sb.AppendLine();
                    }
                }
            }

            File.WriteAllText(path, sb.ToString());
        }

        /// <summary>
        /// Get all the key names in a section
        /// </summary>
        /// <param name="section">section</param>
        /// <returns>string array</returns>
        public string[] GetKeys(string section)
        {
            if (!ini.ContainsKey(section))
                return new string[0];

            return ini[section].Keys.ToArray();
        }

        /// <summary>
        /// Get all the values in a section
        /// </summary>
        /// <param name="section">section</param>
        /// <returns>string array</returns>
        public string[] GetValues(string section)
        {
            if (!ini.ContainsKey(section))
                return new string[0];

            return ini[section].Values.ToArray();
        }

        /// <summary>
        /// Get all the section names of the INI file
        /// </summary>
        /// <returns>string array</returns>
        public string[] GetSections()
        {
            return ini.Keys.Where(t => t != "").ToArray();
        }

        /// <summary>
        /// Returns a parameter value in the section, with a default value if not found
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public string IniReadValue(string section, string key, string defaultValue = "")
        {
            if (!ini.ContainsKey(section))
                return defaultValue;

            if (!ini[section].ContainsKey(key))
                return defaultValue;

            return ini[section][key];
        }

        /// <summary>
        /// Writes a string value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void IniWriteValue(string section, string key, string value)
        {
            Dictionary<string, string> currentSection;
            if (!ini.ContainsKey(section))
            {
                currentSection = new Dictionary<string, string>();
                ini.Add(section, currentSection);
            }
            else
                currentSection = ini[section];

            currentSection[key] = value;
            Save();
        }

        #region Delphi Inspired Read Methods

        /// <summary>
        /// Retrieves a boolean value from an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="defaultValue">The value to return if not found.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public bool ReadBool(string section, string key, bool defaultValue)
        {
            bool b;
            return BoolParser.TryParse(IniReadValue(section, key), out b) ? b : defaultValue;
        }

        /// <summary>
        /// Retrieves a date-time value from an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="defaultValue">The value to return if not found.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public DateTime ReadDateTime(string section, string key, DateTime defaultValue)
        {
            DateTime dt;
            return DateTime.TryParse(IniReadValue(section, key), out dt) ? dt : defaultValue;
        }

        /// <summary>
        /// Retrieves a float value from an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="defaultValue">The value to return if not found.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public float ReadFloat(string section, string key, float defaultValue)
        {
            float f;
            return float.TryParse(IniReadValue(section, key), out f) ? f : defaultValue;
        }

        /// <summary>
        /// Retrieves a integer value from an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="defaultValue">The value to return if not found.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public int ReadInteger(string section, string key, int defaultValue)
        {
            int i;
            return int.TryParse(IniReadValue(section, key), out i) ? i : defaultValue;
        }

        /// <summary>
        /// Reads all the key names from a specified section of an ini file into a string list.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="strings">specifies the string list to hold the retrieved names.</param>
        public void ReadSection(string section, out List<string> strings)
        {
            strings = GetKeys(section).ToList();
        }

        /// <summary>
        /// Reads the names of all sections in an ini file into a string list.
        /// </summary>
        /// <param name="strings">specifies the string list to hold the retrieved names.</param>
        public void ReadSections(out List<string> strings)
        {
            strings = GetSections().ToList();
        }

        /// <summary>
        /// Reads the values from all keys within a section of an ini file into a string list.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="strings">specifies the string list to hold the retrieved names.</param>
        public void ReadSectionValues(string section, out List<string> strings)
        {
            strings = GetValues(section).ToList();
        }

        /// <summary>
        /// Retrieves a string value from an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="defaultValue">The value to return if not found.</param>
        /// <returns>value if found, defaultValue otherwise.</returns>
        public string ReadString(string section, string key, string defaultValue)
        {
            return IniReadValue(section, key, defaultValue);
        }

        /// <summary>
        /// Indicates whether a section exists in the ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <returns><c>true</c> if section exists, <c>false</c> otherwise.</returns>
        public bool SectionExists(string section)
        {
            return ini.ContainsKey(section);
        }

        #endregion

        #region Delphi Inspired Write Methods

        /// <summary>
        /// Writes a boolean value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        /// <param name="outputType">The output type of the boolean value written to the ini file.</param>
        public void WriteBool(string section, string key, bool value, BoolStringType outputType = BoolStringType.Integer)
        {
            switch (outputType)
            {
                case BoolStringType.StringTrueFalse:
                    IniWriteValue(section, key, value.ToString());
                    break;
                case BoolStringType.StringYesNo:
                    IniWriteValue(section, key, value ? "Yes" : "No");
                    break;
                case BoolStringType.CharTF:
                    IniWriteValue(section, key, value ? "T" : "F");
                    break;
                case BoolStringType.CharYN:
                    IniWriteValue(section, key, value ? "Y" : "N");
                    break;
                default:
                    IniWriteValue(section, key, value ? "1" : "0");
                    break;
            }
        }

        /// <summary>
        /// Writes a date value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteDate(string section, string key, DateTime value)
        {
            IniWriteValue(section, key, value.ToShortDateString());
        }

        /// <summary>
        /// Writes a date-time value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteDateTime(string section, string key, DateTime value)
        {
            IniWriteValue(section, key, value.ToString());
        }

        /// <summary>
        /// Writes a float value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteFloat(string section, string key, float value)
        {
            IniWriteValue(section, key, value.ToString());
        }

        /// <summary>
        /// Writes a integer value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteInteger(string section, string key, int value)
        {
            IniWriteValue(section, key, value.ToString());
        }

        /// <summary>
        /// Writes a string value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteString(string section, string key, string value)
        {
            IniWriteValue(section, key, value);
        }

        /// <summary>
        /// Writes a time value to an ini file.
        /// </summary>
        /// <param name="section">The section of the ini file.</param>
        /// <param name="key">The key of the ini file section.</param>
        /// <param name="value">The value to write to the ini file.</param>
        public void WriteTime(string section, string key, DateTime value)
        {
            IniWriteValue(section, key, value.ToShortTimeString());
        }

        #endregion
    }

    /// <summary>
    /// Class BoolParser.
    /// </summary>
    /// <remarks>
    /// This class exposes an alternate TryParse method that parses a 
    /// string for all possible ways to specify a true/false value and 
    /// returns the boolean result.
    /// </remarks>
    public static class BoolParser
    {
        private static readonly List<string> TrueString = new List<string>(new string[] { "true", "t", "1", "yes", "y" });

        private static readonly List<string> FalseString = new List<string>(new string[] { "false", "f", "0", "no", "n" });

        /// <summary>
        /// Converts the specified string representation of a logical value to its System.Boolean
        /// equivalent. A return value indicates whether the conversion succeeded or
        /// failed.
        /// </summary>
        /// <param name="value">A string containing the value to convert.</param>
        /// <param name="result">When this method returns, if the conversion succeeded, contains true if value
        /// is equivalent to a string in the TrueString list or false if value is equivalent
        /// to a string in the FalseString list. If the conversion failed, contains false.
        /// The conversion fails if value is null or is not equivalent to either System.Boolean.TrueString
        /// or System.Boolean.FalseString.</param>
        /// <returns><c>true</c> if value was converted successfully; <c>false</c> otherwise.</returns>
        public static bool TryParse(string value, out bool result)
        {
            string formattedInput = value.Trim().ToLower();

            if (TrueString.Contains(formattedInput))
            {
                result = true;
                return true;
            }
            else if (FalseString.Contains(formattedInput))
            {
                result = false;
                return true;
            }
            else
            {
                result = false;
                return false;
            }
        }
    }
}
