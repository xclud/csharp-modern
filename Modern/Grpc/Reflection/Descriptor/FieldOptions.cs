namespace Modern.Grpc.Reflection.Descriptor;

public sealed record FieldOptions : IMessage<FieldOptions>
{
    //  // The ctype option instructs the C++ code generator to use a different
    //  // representation of the field than it normally would.  See the specific
    //  // options below.  This option is not yet implemented in the open source
    //  // release -- sorry, we'll try to include it in a future version!
    //  optional CType ctype = 1 [default = STRING];
    //  enum CType {
    //    // Default mode.
    //    STRING; // 0

    //    CORD; // 1

    //    STRING_PIECE; // 2
    //  }
    //  // The packed option can be enabled for repeated primitive fields to enable
    //  // a more efficient representation on the wire. Rather than repeatedly
    //  // writing the tag and type for each element, the entire array is encoded as
    //  // a single length-delimited blob. In proto3, only explicit setting it to
    //  // false will avoid using packed encoding.
    //  public bool? packed; // 2

    //  // The jstype option determines the JavaScript type used for values of the
    //  // field.  The option is permitted only for 64 bit integral and fixed types
    //  // (int64, uint64, sint64, fixed64, sfixed64).  A field with jstype JS_STRING
    //  // is represented as JavaScript string, which avoids loss of precision that
    //  // can happen when a large value is converted to a floating point JavaScript.
    //  // Specifying JS_NUMBER for the jstype causes the generated JavaScript code to
    //  // use the JavaScript "number" type.  The behavior of the default option
    //  // JS_NORMAL is implementation dependent.
    //  //
    //  // This option is an enum to permit additional types to be added, e.g.
    //  // goog.math.Integer.
    //  optional JSType jstype = 6 [default = JS_NORMAL];
    public enum JSType
    {
        /// <summary>
        /// Use the default type.
        /// </summary>
        JS_NORMAL = 0,

        /// <summary>
        /// Use JavaScript strings.
        /// </summary>
        JS_STRING = 1,

        /// <summary>
        /// Use JavaScript numbers.
        /// </summary>
        JS_NUMBER = 2
    }

    //  // Should this field be parsed lazily?  Lazy applies only to message-type
    //  // fields.  It means that when the outer message is initially parsed, the
    //  // inner message's contents will not be parsed but instead stored in encoded
    //  // form.  The inner message will actually be parsed when it is first accessed.
    //  //
    //  // This is only a hint.  Implementations are free to choose whether to use
    //  // eager or lazy parsing regardless of the value of this option.  However,
    //  // setting this option true suggests that the protocol author believes that
    //  // using lazy parsing on this field is worth the additional bookkeeping
    //  // overhead typically needed to implement it.
    //  //
    //  // This option does not affect the public interface of any generated code;
    //  // all method signatures remain the same.  Furthermore, thread-safety of the
    //  // interface is not affected by this option; const methods remain safe to
    //  // call from multiple threads concurrently, while non-const methods continue
    //  // to require exclusive access.
    //  //
    //  //
    //  // Note that implementations may choose not to check required fields within
    //  // a lazy sub-message.  That is, calling IsInitialized() on the outer message
    //  // may return true even if the inner message has missing required fields.
    //  // This is necessary because otherwise the inner message would have to be
    //  // parsed in order to perform the check, defeating the purpose of lazy
    //  // parsing.  An implementation which chooses not to check required fields
    //  // must be consistent about it.  That is, for any particular sub-message, the
    //  // implementation must either *always* check its required fields, or *never*
    //  // check its required fields, regardless of whether or not the message has
    //  // been parsed.
    //  public bool? lazy = 5 [default = false];

    //  // Is this field deprecated?
    //  // Depending on the target platform, this can emit Deprecated annotations
    //  // for accessors, or it will be completely ignored; in the very least, this
    //  // is a formalization for deprecating fields.
    //  public bool? deprecated = 3 [default = false];

    //  // For Google-internal migration only. Do not use.
    //  public bool? weak = 10 [default = false];


    //  // The parser stores options it doesn't recognize here. See above.
    //  repeated UninterpretedOption uninterpreted_option; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;

    //  reserved 4;  // removed jtype
    public static FieldOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        throw new NotImplementedException();
    }
}
