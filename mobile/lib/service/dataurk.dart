import 'dart:convert';
import 'dart:io';

import 'package:assignments/model/request_urkmodel.dart';
import 'package:assignments/repository/requestrep.dart';
import 'package:flutter/material.dart';
import 'package:path_provider/path_provider.dart';
import 'package:provider/provider.dart';

class DataUserService {
  Future<String> getFilePath() async {
    Directory appDocumentsDirectory = await getApplicationDocumentsDirectory();

    String appDocumentsPath = appDocumentsDirectory.path; // 2
    String filePath = '$appDocumentsPath/dataurk.txt'; // 3

    return filePath;
  }

  void saveFile(RequestUrkModel useritems) async {
    File file = File(await getFilePath()); // 1
    String fileContent = await file.readAsString();

    List<RequestUrkModel> list = [];

    if (fileContent.length > 2) {
      list = json
          .decode(fileContent)
          .map<RequestUrkModel>((e) => RequestUrkModel.fromJson(e))
          .toList();
    }
     
     
    list.add(useritems);
    String writeContent = json.encode(list);
    file.writeAsString(writeContent);
    // 2
  }

  void readFile(BuildContext context) async {
    File file = File(await getFilePath());
    if (await file.exists()) {
      String fileContent = await file.readAsString();
      print(fileContent);
      List<RequestUrkModel> list = [];
      if (fileContent.length > 2) {
        list = json
            .decode(fileContent)
            .map<RequestUrkModel>((e) => RequestUrkModel.fromJson(e))
            .toList();
      }
      Provider.of<RequestRep>(context, listen: false).addItem(list);
    }
  }

  void deleteFile() async {
    File file = File(await getFilePath());
    file.delete();
  }

  void createFile() async {
    File file = File(await getFilePath());
    file.create();
  }
}