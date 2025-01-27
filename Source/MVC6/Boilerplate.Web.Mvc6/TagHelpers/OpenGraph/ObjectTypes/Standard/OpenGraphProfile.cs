﻿namespace Boilerplate.Web.Mvc.TagHelpers.OpenGraph
{
    using System.Text;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    /// <summary>
    /// This object type represents a person. While appropriate for celebrities, artists, or musicians, this object type can be used for the profile of 
    /// any individual. This object type is part of the Open Graph standard.
    /// See http://ogp.me/
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/profile/
    /// </summary>
    [TargetElement(nameof(OpenGraphProfile), Attributes = nameof(Title) + "," + nameof(MainImage))]
    public class OpenGraphProfile : OpenGraphMetadata
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphProfile"/> class.
        /// </summary>
        public OpenGraphProfile() : base()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphProfile"/> class.
        /// </summary>
        /// <param name="title">The title of the object as it should appear in the graph.</param>
        /// <param name="mainImage">The main image which should represent your object within the graph. This is a required property.</param>
        /// <param name="url">The canonical URL of the object, used as its ID in the graph. Leave as <c>null</c> to get the URL of the current page.</param>
        public OpenGraphProfile(string title, OpenGraphImage mainImage, string url = null)
            : base(title, mainImage, url)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the name normally given to an individual by a parent or self-chosen.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public OpenGraphGender? Gender { get; set; }

        /// <summary>
        /// Gets or sets the name inherited from a family or marriage and by which the individual is commonly known.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace { get { return "profile: http://ogp.me/ns/profile#"; } }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type { get { return OpenGraphType.Profile; } }

        /// <summary>
        /// Gets or sets the short unique string to identify them.
        /// </summary>
        public string Username { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            stringBuilder.AppendMetaPropertyContentIfNotNull("profile:first_name", this.FirstName);
            stringBuilder.AppendMetaPropertyContentIfNotNull("profile:last_name", this.LastName);
            stringBuilder.AppendMetaPropertyContentIfNotNull("profile:username", this.Username);

            if (this.Gender.HasValue)
            {
                stringBuilder.AppendMetaPropertyContent("profile:gender", this.Gender.Value.ToLowercaseString());
            }
        } 

        #endregion
    }
}
