# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: ImageProcessingService.proto
"""Generated protocol buffer code."""
from google.protobuf.internal import builder as _builder
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\x1cImageProcessingService.proto\".\n\x0cImageRequest\x12\x0e\n\x06image1\x18\x01 \x01(\x0c\x12\x0e\n\x06image2\x18\x02 \x01(\x0c\"L\n\rImageResponse\x12\x15\n\rresult_image1\x18\x01 \x01(\x0c\x12\x15\n\rresult_image2\x18\x02 \x01(\x0c\x12\r\n\x05value\x18\x03 \x01(\x05\x32L\n\x16ImageProcessingService\x12\x32\n\rProcessImages\x12\r.ImageRequest\x1a\x0e.ImageResponse\"\x00\x30\x01\x42\x12\xaa\x02\x0fImageProcessingb\x06proto3')

_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, globals())
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'ImageProcessingService_pb2', globals())
if _descriptor._USE_C_DESCRIPTORS == False:

  DESCRIPTOR._options = None
  DESCRIPTOR._serialized_options = b'\252\002\017ImageProcessing'
  _IMAGEREQUEST._serialized_start=32
  _IMAGEREQUEST._serialized_end=78
  _IMAGERESPONSE._serialized_start=80
  _IMAGERESPONSE._serialized_end=156
  _IMAGEPROCESSINGSERVICE._serialized_start=158
  _IMAGEPROCESSINGSERVICE._serialized_end=234
# @@protoc_insertion_point(module_scope)
