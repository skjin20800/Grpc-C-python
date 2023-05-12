import grpc
import ImageProcessingService_pb2
import ImageProcessingService_pb2_grpc
import numpy as np
import cv2
from concurrent import futures

class ImageProcessingService(ImageProcessingService_pb2_grpc.ImageProcessingService):
    def ProcessImages(self, request, context):
        print("함수실행")
        image1 = self._to_mat(request.image1)
        image2 = self._to_mat(request.image2)
        #cv2.imwrite(r'D:\test\a3.png',image1)
        
        result_image1 = image1
        result_image2 = image2
        value = 123
        print("함수값?11 ")
        try:
            response = ImageProcessingService_pb2.ImageResponse(
                result_image1=self._to_bytes(result_image1),
                
                result_image2=self._to_bytes(result_image2),
                value=value
            )
            #cv2.imwrite(r'D:\test\a4.png',result_image1),
            yield response
        except:
            traceback.print_exc()
        print("testtest")

    def _to_mat(self, image_bytes):
        np_array = np.frombuffer(image_bytes, np.uint8)
        return cv2.imdecode(np_array, cv2.IMREAD_COLOR)

    def _to_bytes(self, image):
        retval, buffer = cv2.imencode('.jpg', image)
        return buffer.tobytes()

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    ImageProcessingService_pb2_grpc.add_ImageProcessingServiceServicer_to_server(ImageProcessingService(), server)
    server.add_insecure_port('[::]:50052')
    server.start()
    print("start")
    server.wait_for_termination()

if __name__ == '__main__':
    serve()