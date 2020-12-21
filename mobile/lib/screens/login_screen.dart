import 'package:assignments/components/input.dart';
import 'package:assignments/screens/admin_screen.dart';

import 'package:flutter/material.dart';

import 'home_screen.dart';

class LoginScreen extends StatefulWidget {
  _LoginScreen createState() => _LoginScreen();
}

class _LoginScreen extends State<LoginScreen> {
  static TextEditingController _emailController = TextEditingController();
  static TextEditingController _passwordController = TextEditingController();
  final LoginInputWidget login = LoginInputWidget(
      icon: Icon(Icons.email),
      hint: "EMAIL",
      obscure: false,
      controller: _emailController,
      isPassword: false);
  final LoginInputWidget password = LoginInputWidget(
      icon: Icon(Icons.lock),
      hint: "PASSWORD",
      obscure: true,
      controller: _passwordController,
      isPassword: true);
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  onLogin() {
    if (_formKey.currentState.validate() && _emailController.text == 'user@gmail.com') {
      _formKey.currentState.save();
      Navigator.of(context)
          .pushReplacement(MaterialPageRoute(builder: (BuildContext context) {
        return HomeScreen();
      }));
    } else if(_formKey.currentState.validate() && _emailController.text == 'admin@gmail.com'){
       _formKey.currentState.save();
      Navigator.of(context)
          .pushReplacement(MaterialPageRoute(builder: (BuildContext context) {
        return AdminScreen();
    }));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: Form(
          key: _formKey,
          autovalidate: true,
          child: ListView(
            children: <Widget>[
              Container(
                width: MediaQuery.of(context).size.width,
                height: MediaQuery.of(context).size.height / 3.5,
                decoration: BoxDecoration(
                    gradient: LinearGradient(
                      begin: Alignment.topCenter,
                      end: Alignment.bottomCenter,
                      colors: [
                        Theme.of(context).primaryColor,
                        Theme.of(context).primaryColorDark
                      ],
                    ),
                    borderRadius:
                        BorderRadius.only(bottomLeft: Radius.circular(90))),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Spacer(),
                    Align(
                      alignment: Alignment.bottomRight,
                      child: Padding(
                        padding: const EdgeInsets.only(bottom: 32, right: 32),
                        child: Text(
                          'Login',
                          style: TextStyle(color: Colors.white, fontSize: 18),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              Container(
                height: MediaQuery.of(context).size.height / 2,
                width: MediaQuery.of(context).size.width,
                padding: EdgeInsets.only(top: 50),
                child: Column(
                  children: <Widget>[
                    Container(child: login),
                    Container(child: password),
                    InkWell(
                      onTap: () {
                        onLogin();
                      },
                      child: Container(
                        margin: EdgeInsets.only(top: 30),
                        height: 45,
                        width: MediaQuery.of(context).size.width / 1.2,
                        decoration: BoxDecoration(
                          gradient: LinearGradient(
                            colors: [
                              Theme.of(context).primaryColor,
                              Theme.of(context).primaryColorDark,
                            ],
                          ),
                          borderRadius: BorderRadius.all(
                            Radius.circular(50),
                          ),
                        ),
                        child: Center(
                          child: Text(
                            'LOGIN',
                            style: TextStyle(
                                color: Colors.white,
                                fontWeight: FontWeight.bold),
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
