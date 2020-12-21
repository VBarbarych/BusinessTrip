import 'package:assignments/screens/listfile_screen.dart';
import 'package:assignments/screens/request_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  int _currentIndex = 0;
  final List<Widget> _children = [RequestScreen(), ListFileScreen()];

  @override
  void initState() {
    super.initState();
  }

  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
        onWillPop: () async => false,
        child: AnnotatedRegion<SystemUiOverlayStyle>(
            value: SystemUiOverlayStyle.dark,
            child: Scaffold(
              body: _children[_currentIndex],
              bottomNavigationBar: BottomNavigationBar(
                currentIndex: _currentIndex,
                iconSize: 30,
                unselectedFontSize: 12,
                selectedFontSize: 12,
                //currentIndex: _currentIndex,
                type: BottomNavigationBarType.fixed,

                items: [
                  BottomNavigationBarItem(
                    icon: Icon(Icons.search),
                    title: Container(
                        height: 30,
                        child: Column(children: [
                          Container(
                              padding: EdgeInsets.only(left: 10, top: 6),
                              child: Text(
                                'Запит',
                              )),
                          SizedBox(
                            height: 7,
                          ),
                          
                        ])),
                  ),
                  BottomNavigationBarItem(
                    icon: Icon(Icons.content_paste),
                    title: Container(
                        height: 30,
                        child: Column(children: [
                          Container(
                              padding: EdgeInsets.only(top: 6),
                              child: Text(
                                'Файли',
                              )),
                         SizedBox(
                            height: 7,
                          ),
                        ])),
                    backgroundColor: Colors.white,
                  ),
                ],
                onTap: (index) {
                  
                  setState(() {
                    _currentIndex = index;
                  });
                },
              ),
            )));
  }
}