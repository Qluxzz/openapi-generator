// <auto-generated>
/*
 * OpenAPI Petstore
 *
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using OpenAPIClientUtils = Org.OpenAPITools.Client.ClientUtils;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// PolymorphicProperty
    /// </summary>
    public partial class PolymorphicProperty : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class.
        /// </summary>
        /// <param name="_bool"></param>
        [JsonConstructor]
        internal PolymorphicProperty(bool _bool)
        {
            Bool = _bool;
            OnCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class.
        /// </summary>
        /// <param name="_string"></param>
        [JsonConstructor]
        internal PolymorphicProperty(string _string)
        {
            String = _string;
            OnCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class.
        /// </summary>
        /// <param name="_object"></param>
        [JsonConstructor]
        internal PolymorphicProperty(Object _object)
        {
            Object = _object;
            OnCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class.
        /// </summary>
        /// <param name="liststring"></param>
        [JsonConstructor]
        internal PolymorphicProperty(List<string> liststring)
        {
            Liststring = liststring;
            OnCreated();
        }

        partial void OnCreated();

        /// <summary>
        /// Gets or Sets Bool
        /// </summary>
        public bool Bool { get; set; }

        /// <summary>
        /// Gets or Sets String
        /// </summary>
        public string String { get; set; }

        /// <summary>
        /// Gets or Sets Object
        /// </summary>
        public Object Object { get; set; }

        /// <summary>
        /// Gets or Sets Liststring
        /// </summary>
        public List<string> Liststring { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JsonElement> AdditionalProperties { get; } = new Dictionary<string, JsonElement>();

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PolymorphicProperty {\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// A Json converter for type PolymorphicProperty
    /// </summary>
    public class PolymorphicPropertyJsonConverter : JsonConverter<PolymorphicProperty>
    {
        /// <summary>
        /// A Json reader.
        /// </summary>
        /// <param name="utf8JsonReader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public override PolymorphicProperty Read(ref Utf8JsonReader utf8JsonReader, Type typeToConvert, JsonSerializerOptions jsonSerializerOptions)
        {
            int currentDepth = utf8JsonReader.CurrentDepth;

            if (utf8JsonReader.TokenType != JsonTokenType.StartObject && utf8JsonReader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            JsonTokenType startingTokenType = utf8JsonReader.TokenType;

            while (utf8JsonReader.Read())
            {
                if (startingTokenType == JsonTokenType.StartObject && utf8JsonReader.TokenType == JsonTokenType.EndObject && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (startingTokenType == JsonTokenType.StartArray && utf8JsonReader.TokenType == JsonTokenType.EndArray && currentDepth == utf8JsonReader.CurrentDepth)
                    break;

                if (utf8JsonReader.TokenType == JsonTokenType.PropertyName && currentDepth == utf8JsonReader.CurrentDepth - 1)
                {
                    string propertyName = utf8JsonReader.GetString();
                    utf8JsonReader.Read();

                    switch (propertyName)
                    {
                        default:
                            break;
                    }
                }
            }

            Utf8JsonReader _boolReader = utf8JsonReader;
            if (Client.ClientUtils.TryDeserialize<bool>(ref _boolReader, jsonSerializerOptions, out bool _bool))
                return new PolymorphicProperty(_bool);

            Utf8JsonReader _stringReader = utf8JsonReader;
            if (Client.ClientUtils.TryDeserialize<string>(ref _stringReader, jsonSerializerOptions, out string _string))
                return new PolymorphicProperty(_string);

            Utf8JsonReader _objectReader = utf8JsonReader;
            if (Client.ClientUtils.TryDeserialize<Object>(ref _objectReader, jsonSerializerOptions, out Object _object))
                return new PolymorphicProperty(_object);

            Utf8JsonReader liststringReader = utf8JsonReader;
            if (Client.ClientUtils.TryDeserialize<List<string>>(ref liststringReader, jsonSerializerOptions, out List<string> liststring))
                return new PolymorphicProperty(liststring);

            throw new JsonException();
        }

        /// <summary>
        /// A Json writer
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="polymorphicProperty"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Write(Utf8JsonWriter writer, PolymorphicProperty polymorphicProperty, JsonSerializerOptions jsonSerializerOptions)
        {
            System.Text.Json.JsonSerializer.Serialize(writer, polymorphicProperty.Bool, jsonSerializerOptions);

            System.Text.Json.JsonSerializer.Serialize(writer, polymorphicProperty.String, jsonSerializerOptions);

            System.Text.Json.JsonSerializer.Serialize(writer, polymorphicProperty.Object, jsonSerializerOptions);

            System.Text.Json.JsonSerializer.Serialize(writer, polymorphicProperty.Liststring, jsonSerializerOptions);

        }
    }
}
