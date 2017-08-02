
// Code generated by a template
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using TabularEditor.PropertyGridUI;
using TabularEditor.UndoFramework;
using System.Drawing.Design;
using TOM = Microsoft.AnalysisServices.Tabular;
namespace TabularEditor.TOMWrapper
{
  
	/// <summary>
///             Represents a column in a Table that is based on a DAX expression. A collection of CalculatedTableColumn, under a Table object bound to a partition with Source of type CalculatedPartitionSource, results in a calculated table.
///             </summary>
	[TypeConverter(typeof(DynamicPropertyConverter))]
	public partial class CalculatedTableColumn: Column
			, IClonableObject
	{
	    protected internal new TOM.CalculatedTableColumn MetadataObject { get { return base.MetadataObject as TOM.CalculatedTableColumn; } internal set { base.MetadataObject = value; } }

/// <summary>Gets or sets a value that indicates whether the name of the column is inferred.</summary><returns>true if the name of the column is inferred; otherwise, false.</returns>
		[DisplayName("Name Inferred")]
		[Category("Other"),Description(@"Gets or sets a value that indicates whether the name of the column is inferred."),IntelliSense("The Name Inferred of this CalculatedTableColumn.")]
		public bool IsNameInferred {
			get {
			    return MetadataObject.IsNameInferred;
			}
			set {
				var oldValue = IsNameInferred;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.ISNAMEINFERRED, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsNameInferred = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.ISNAMEINFERRED, oldValue, value));
				OnPropertyChanged(Properties.ISNAMEINFERRED, oldValue, value);
			}
		}
		private bool ShouldSerializeIsNameInferred() { return false; }
/// <summary>Gets or sets a value that indicates whether the data type of the column is inferred.</summary><returns>true if the data type of the column is inferred; otherwise, false.</returns>
		[DisplayName("Data Type Inferred")]
		[Category("Other"),Description(@"Gets or sets a value that indicates whether the data type of the column is inferred."),IntelliSense("The Data Type Inferred of this CalculatedTableColumn.")]
		public bool IsDataTypeInferred {
			get {
			    return MetadataObject.IsDataTypeInferred;
			}
			set {
				var oldValue = IsDataTypeInferred;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.ISDATATYPEINFERRED, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.IsDataTypeInferred = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.ISDATATYPEINFERRED, oldValue, value));
				OnPropertyChanged(Properties.ISDATATYPEINFERRED, oldValue, value);
			}
		}
		private bool ShouldSerializeIsDataTypeInferred() { return false; }
/// <summary>Gets or sets the string source of the column.</summary><returns>A String that contains the source of the column.</returns>
		[DisplayName("Source Column")]
		[Category("Options"),Description(@"Gets or sets the string source of the column."),IntelliSense("The Source Column of this CalculatedTableColumn.")]
		public string SourceColumn {
			get {
			    return MetadataObject.SourceColumn;
			}
			set {
				var oldValue = SourceColumn;
				if (oldValue == value) return;
				bool undoable = true;
				bool cancel = false;
				OnPropertyChanging(Properties.SOURCECOLUMN, value, ref undoable, ref cancel);
				if (cancel) return;
				MetadataObject.SourceColumn = value;
				if(undoable) Handler.UndoManager.Add(new UndoPropertyChangedAction(this, Properties.SOURCECOLUMN, oldValue, value));
				OnPropertyChanged(Properties.SOURCECOLUMN, oldValue, value);
			}
		}
		private bool ShouldSerializeSourceColumn() { return false; }
/// <summary>Gets the origin of the column.</summary><returns>The origin of the column.</returns>
		[DisplayName("Column Origin")]
		[Category("Other"),Description(@"Gets the origin of the column."),IntelliSense("The Column Origin of this CalculatedTableColumn.")]
		public Column ColumnOrigin {
			get {
				if (MetadataObject.ColumnOrigin == null) return null;
			    return Handler.WrapperLookup[MetadataObject.ColumnOrigin] as Column;
            }
			
		}
		private bool ShouldSerializeColumnOrigin() { return false; }

		public static CalculatedTableColumn CreateFromMetadata(TOM.CalculatedTableColumn metadataObject, bool init = true) {
			var obj = new CalculatedTableColumn(metadataObject, init);
			if(init) 
			{
				obj.InternalInit();
				obj.Init();
			}
			return obj;
		}


		/// <summary>
		/// Creates a new CalculatedTableColumn and adds it to the parent Table.
		/// Also creates the underlying metadataobject and adds it to the TOM tree.
		/// </summary>
		public static CalculatedTableColumn CreateNew(Table parent, string name = null)
		{
			var metadataObject = new TOM.CalculatedTableColumn();
			metadataObject.Name = parent.Columns.GetNewName(string.IsNullOrWhiteSpace(name) ? "New CalculatedTableColumn" : name);

			var obj = new CalculatedTableColumn(metadataObject);

			parent.Columns.Add(obj);
			
			obj.Init();

			return obj;
		}


		/// <summary>
		/// Creates an exact copy of this CalculatedTableColumn object.
		/// </summary>
		public CalculatedTableColumn Clone(string newName = null, bool includeTranslations = true, Table newParent = null) {
		    Handler.BeginUpdate("Clone CalculatedTableColumn");

			// Create a clone of the underlying metadataobject:
			var tom = MetadataObject.Clone() as TOM.CalculatedTableColumn;


			// Assign a new, unique name:
			tom.Name = Parent.Columns.MetadataObjectCollection.GetNewName(string.IsNullOrEmpty(newName) ? tom.Name + " copy" : newName);
				
			// Create the TOM Wrapper object, representing the metadataobject (but don't init until after we add it to the parent):
			var obj = CreateFromMetadata(tom, false);

			// Add the object to the parent collection:
			if(newParent != null) 
				newParent.Columns.Add(obj);
			else
    			Parent.Columns.Add(obj);

			obj.InternalInit();
			obj.Init();

			// Copy translations, if applicable:
			if(includeTranslations) {
				// TODO: Copy translations of child objects

				obj.TranslatedNames.CopyFrom(TranslatedNames);
				obj.TranslatedDescriptions.CopyFrom(TranslatedDescriptions);
				obj.TranslatedDisplayFolders.CopyFrom(TranslatedDisplayFolders);
			}
				
			// Copy perspectives:
			obj.InPerspective.CopyFrom(InPerspective);

            Handler.EndUpdate();

            return obj;
		}

		TabularNamedObject IClonableObject.Clone(string newName, bool includeTranslations, TabularNamedObject newParent) 
		{
			return Clone(newName);
		}

	
        internal override void RenewMetadataObject()
        {
            Handler.WrapperLookup.Remove(MetadataObject);
            MetadataObject = MetadataObject.Clone() as TOM.CalculatedTableColumn;
            Handler.WrapperLookup.Add(MetadataObject, this);
        }

		public Table Parent { 
			get {
				return Handler.WrapperLookup[MetadataObject.Parent] as Table;
			}
		}



		/// <summary>
		/// CTOR - only called from static factory methods on the class
		/// </summary>
		protected CalculatedTableColumn(TOM.CalculatedTableColumn metadataObject, bool init = true) : base(metadataObject)
		{
			if(init) InternalInit();
		}

		private void InternalInit()
		{
		}



		internal override void Undelete(ITabularObjectCollection collection) {
			base.Undelete(collection);
			Reinit();
			ReapplyReferences();
		}

		public override bool Browsable(string propertyName) {
			switch (propertyName) {
				case Properties.PARENT:
					return false;
				
				default:
					return base.Browsable(propertyName);
			}
		}

    }

}
