import 'package:flutter/material.dart';

class LoginInputWidget extends StatelessWidget {
  final Icon icon;
  final String hint;
  final bool obscure;
  final TextEditingController controller;
  final bool isPassword;
  LoginInputWidget(
      {this.icon, this.hint, this.obscure, this.controller, this.isPassword});
  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width / 1.2,
      height: 55,
      padding: EdgeInsets.only(bottom: 15, left: 10),
      margin: EdgeInsets.only(top: 20),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.all(Radius.circular(50)),
        color: Colors.white,
        boxShadow: [
          BoxShadow(color: Colors.black26, blurRadius: 5),
        ],
      ),
      child: TextFormField(
        controller: controller,
        obscureText: obscure,
        keyboardType:
            isPassword ? TextInputType.text : TextInputType.emailAddress,
        validator: isPassword ? validatePassword : validateEmail,
        style: TextStyle(
            fontSize: 15, color: Colors.black, fontWeight: FontWeight.bold),
        decoration: InputDecoration(
          contentPadding: EdgeInsets.only(top: 14),
          border: InputBorder.none,
          icon: Padding(
            padding: EdgeInsets.only(top: 20),
            child: IconTheme(
                data: IconThemeData(
                  color: Theme.of(context).accentColor,
                ),
                child: icon),
          ),
          hintText: hint,
        ),
      ),
    );
  }

  String validatePassword(String value) {
    if (value.length < 6)
      return 'Name must be more than 5 charater';
    else
      return null;
  }

  String validateEmail(String value) {
    Pattern pattern =
        r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
    RegExp regex = new RegExp(pattern);
    if (!regex.hasMatch(value))
      return 'Enter Valid Email';
    else
      return null;
  }
}
