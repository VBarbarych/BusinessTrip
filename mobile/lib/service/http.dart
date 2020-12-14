import 'package:dio/dio.dart';


class HttpService {
  static BaseOptions _options =
      BaseOptions(baseUrl: '');
  static String token = '';
  static Dio dio = new Dio(_options)..interceptors.add(RequestInterceptor());

  
  static Future<Response<List<int>>> post(String path, dynamic data) {
    return dio.post(path, data: data,options: Options(responseType: ResponseType.bytes));
  }
  Future<Response> get(String path) {
    return dio.get(path);
  }
  
}

class RequestInterceptor extends Interceptor {
  @override
  Future onResponse(Response response) {
    return super.onResponse(response);
  }

  @override
  Future onError(DioError err) async {
    await _handleResponse(err.response);
    return super.onError(err);
  }

  Future _handleResponse(Response response) async {
    switch (response.statusCode) {
      case 400:
        throw BadRequestException(
            message: 'Bad Request ', code: response.statusCode);
      case 404:
        throw NotFoundException(
            message: 'Url not found', code: response.statusCode);
      case 404:
    }
  }
}

class CustomAppException implements Exception {
  final String message;
  final int code;

  CustomAppException({this.message, this.code});
}

class BadRequestException extends CustomAppException {
  BadRequestException({String message, int code})
      : super(message: message, code: code);
}

class UnAuthorizedException extends CustomAppException {
  UnAuthorizedException({String message, int code})
      : super(message: message, code: code);
}

class NotFoundException extends CustomAppException {
  NotFoundException({String message, int code})
      : super(message: message, code: code);
}