# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import ImageProcessingService_pb2 as ImageProcessingService__pb2


class ImageProcessingServiceStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.ProcessImages = channel.unary_stream(
                '/ImageProcessingService/ProcessImages',
                request_serializer=ImageProcessingService__pb2.ImageRequest.SerializeToString,
                response_deserializer=ImageProcessingService__pb2.ImageResponse.FromString,
                )


class ImageProcessingServiceServicer(object):
    """Missing associated documentation comment in .proto file."""

    def ProcessImages(self, request, context):
        """Missing associated documentation comment in .proto file."""
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_ImageProcessingServiceServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'ProcessImages': grpc.unary_stream_rpc_method_handler(
                    servicer.ProcessImages,
                    request_deserializer=ImageProcessingService__pb2.ImageRequest.FromString,
                    response_serializer=ImageProcessingService__pb2.ImageResponse.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'ImageProcessingService', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class ImageProcessingService(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def ProcessImages(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_stream(request, target, '/ImageProcessingService/ProcessImages',
            ImageProcessingService__pb2.ImageRequest.SerializeToString,
            ImageProcessingService__pb2.ImageResponse.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)
