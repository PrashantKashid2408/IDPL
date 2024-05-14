using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Core.Entity
{
    public class EventLogs
    {
        #region Declarations

         private bool _boolObjectChanged;
private int _intId;
private string _strEvent;
private int _intEventBy;
private byte _bytStatusId;
private DateTime _datCreatedDate;
private DateTime _datUpdatedDate;


        #endregion Declarations

        #region Properties

         public bool ObjectChanged
 { 
    get { return this._boolObjectChanged; } 
    set { this._boolObjectChanged = value; }
 } 

 public int Id
 { 
    get { return this._intId; } 
    set { this._intId = value; }
 } 

 public string Event
 { 
    get { return this._strEvent; } 
    set { this._strEvent = value; }
 } 

 public int EventBy
 { 
    get { return this._intEventBy; } 
    set { this._intEventBy = value; }
 } 

 public byte StatusId
 { 
    get { return this._bytStatusId; } 
    set { this._bytStatusId = value; }
 } 

 public DateTime CreatedDate
 { 
    get { return this._datCreatedDate; } 
    set { this._datCreatedDate = value; }
 } 

 public DateTime UpdatedDate
 { 
    get { return this._datUpdatedDate; } 
    set { this._datUpdatedDate = value; }
 } 



        #endregion Properties
    }
}
