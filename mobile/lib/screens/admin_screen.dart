import 'package:assignments/repository/requestrep.dart';
import 'package:assignments/service/dataeur.dart';
import 'package:assignments/service/dataurk.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class AdminScreen extends StatefulWidget {
  @override
  _AdminScreenState createState() => _AdminScreenState();
}

class _AdminScreenState extends State<AdminScreen> {
  @override
  void initState() {
    super.initState();
    DataUserEurService().readFile(context);
    DataUserService().readFile(context);
  }

  bool _currentIndex = false;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: Text('Admin Panel')),
        body: SingleChildScrollView(child:Column(children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              
              Container(
                width: MediaQuery.of(context).size.width / 2.4,
                child: MaterialButton(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                  color: _currentIndex ? Colors.white : Colors.blue,
                  onPressed: () {
                    setState(() {
                      _currentIndex = false;
                    });
                  },
                  child: Text(
                    'Ukrainian request',
                    style: GoogleFonts.roboto(
                      color: _currentIndex ? Colors.grey : Colors.white,
                      fontSize: 15,
                    ),
                  ),
                ),
              ),
              SizedBox(
                width: 20,
              ),
              Container(
                width: MediaQuery.of(context).size.width / 2.4,
                child: MaterialButton(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                  color: _currentIndex ? Colors.blue : Colors.white,
                  onPressed: () {
                    setState(() {
                      _currentIndex = true;
                    });
                  },
                  child: Text('Europe request',
                      style: GoogleFonts.roboto(
                        color: _currentIndex ? Colors.white : Colors.grey,
                        fontSize: 15,
                      )),
                ),
              ),
            ],
          ),
          SizedBox(
            height: 10,
          ),
          !_currentIndex
              ? Consumer<RequestRep>(builder: (context, object, child) {
                  return Container(
                          padding: EdgeInsets.all(10),
                          child: Column(children: <Widget>[
                            ListView.builder(
                                shrinkWrap: true,
                                physics: ClampingScrollPhysics(),
                                itemCount: object.itemsukr.length,
                                itemBuilder: (context, i) {
                                  return Column(children: <Widget>[
                                    Container(
                                        decoration: BoxDecoration(
                                            borderRadius:
                                                BorderRadius.circular(9),
                                            color: Colors.grey),
                                        child: Column(children: [
                                          Container(
                                            child: Card(
                                              child: Column(
                                                children: <Widget>[
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .username),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i].unit),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .department),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .purpose),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .payment),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i].city),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .insitution),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .dateform),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .dateto),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i].route),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .transport),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .outlay),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemsukr[i]
                                                            .reason),
                                                  ),
                                                ],
                                              ),
                                            ),
                                            padding: EdgeInsets.all(10),
                                          ),
                                          Row(
                                              mainAxisAlignment:
                                                  MainAxisAlignment.center,
                                              children: [
                                                InkWell(
                                                  onTap: null,
                                                  child: Container(
                                                    color: Colors.green,
                                                    child: Text(
                                                      'Accept',
                                                      textAlign:
                                                          TextAlign.center,
                                                    ),
                                                    height: 30,
                                                    width: 100,
                                                    padding:
                                                        EdgeInsets.only(top: 5),
                                                  ),
                                                ),
                                                SizedBox(
                                                  width: 10,
                                                ),
                                                InkWell(
                                                  onTap: null,
                                                  child: Container(
                                                      color: Colors.red,
                                                      child: Text(
                                                        'Cancel',
                                                        textAlign:
                                                            TextAlign.center,
                                                      ),
                                                      height: 30,
                                                      width: 100,
                                                      padding: EdgeInsets.only(
                                                          top: 5)),
                                                ),
                                              ]),
                                          SizedBox(
                                            height: 10,
                                          )
                                        ])),
                                    SizedBox(
                                      height: 10,
                                    )
                                  ]);
                                })
                          ]));
                })
              : Consumer<RequestRep>(builder: (context, object, child) {
                  return Container(
                          padding: EdgeInsets.all(10),
                          child: Column(children: <Widget>[
                            ListView.builder(
                                shrinkWrap: true,
                                physics: ClampingScrollPhysics(),
                                itemCount: object.itemseur.length,
                                itemBuilder: (context, i) {
                                  return Column(children: <Widget>[
                                    Container(
                                        decoration: BoxDecoration(
                                            borderRadius:
                                                BorderRadius.circular(9),
                                            color: Colors.grey),
                                        child: Column(children: [
                                          Container(
                                            child: Card(
                                              child: Column(
                                                children: <Widget>[
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .username),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i].unit),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .department),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .purpose),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .payment),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i].city),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .country),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .insitution),
                                                  ),
                                                  TextFormField(
                                                      enabled: false,
                                                      decoration:
                                                          InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .dateform,
                                                      )),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .dateto),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .outlay),
                                                  ),
                                                  TextFormField(
                                                    enabled: false,
                                                    decoration: InputDecoration(
                                                        labelText: object
                                                            .itemseur[i]
                                                            .reason),
                                                  ),
                                                ],
                                              ),
                                            ),
                                            padding: EdgeInsets.all(10),
                                          ),
                                          Row(
                                              mainAxisAlignment:
                                                  MainAxisAlignment.center,
                                              children: [
                                                InkWell(
                                                  onTap: null,
                                                  child: Container(
                                                    color: Colors.green,
                                                    child: Text(
                                                      'Accept',
                                                      textAlign:
                                                          TextAlign.center,
                                                    ),
                                                    height: 30,
                                                    width: 100,
                                                    padding:
                                                        EdgeInsets.only(top: 5),
                                                  ),
                                                ),
                                                SizedBox(
                                                  width: 10,
                                                ),
                                                InkWell(
                                                  onTap: null,
                                                  child: Container(
                                                      color: Colors.red,
                                                      child: Text(
                                                        'Cancel',
                                                        textAlign:
                                                            TextAlign.center,
                                                      ),
                                                      height: 30,
                                                      width: 100,
                                                      padding: EdgeInsets.only(
                                                          top: 5)),
                                                ),
                                              ]),
                                          SizedBox(
                                            height: 10,
                                          )
                                        ])),
                                    SizedBox(
                                      height: 10,
                                    )
                                  ]);
                                })
                          ]));
                })
        ])));
  }
}
