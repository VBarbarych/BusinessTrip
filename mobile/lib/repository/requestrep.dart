import 'package:assignments/model/request_urkmodel.dart';
import 'package:flutter/material.dart';

class RequestRep extends ChangeNotifier{
   List<RequestUrkModel> itemsukr = [];
   List<RequestUrkModel> itemseur = [];
    List<RequestUrkModel> addItem(List<RequestUrkModel> item) {
    itemsukr= item;
    notifyListeners();
    return itemsukr;
  }
  List<RequestUrkModel> addItemEur(List<RequestUrkModel> item) {
    itemseur= item;
    notifyListeners();
    return itemseur;
  }
}