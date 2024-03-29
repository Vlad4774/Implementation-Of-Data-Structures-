﻿
namespace newJsonProject
{
    class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(new String(),
                                   new Number(),
                                   new Text("true"),
                                   new Text("false"),
                                   new Text("null"));
            var ws = new Many(new Any(" \n\t\r"));
            var separator = new Character(':');
            var element = new Sequence(ws, value, ws);
            var elements = new List(element, new Character(','));
            var arr = new Choice(new Sequence(new Character('['), elements, ws, new Character(']')));
            value.Add(arr);
            var member = new Sequence(ws, new String(), ws, separator, element);
            var members = new List(member, new Character(','));
            var obj = new Choice(new Sequence(new Character('{'), members, ws, new Character('}')));
            value.Add(obj);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
