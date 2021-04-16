using System;
using System.Text;
using System.Collections.Generic;

#nullable enable
#pragma warning disable 1591

namespace ILGPU.Backends.SPIRV {

    /// <summary>
    /// Defines utility methods to generate SPIRV operations
    /// </summary>
    [CLSCompliant(false)]
    public class StringSPIRVBuilder : ISPIRVBuilder {
    
        private StringBuilder _builder = new StringBuilder();
    
        public void GenerateOpNop() {
            _builder.Append("%OpNop");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUndef(uint returnId, uint param1) {
            _builder.Append("%OpUndef");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpSourceContinued(string ContinuedSource) {
            _builder.Append("%OpSourceContinued");
            _builder.Append(ContinuedSource + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSource(SourceLanguage param0, uint Version, uint? File = null, string? Source = null) {
            _builder.Append("%OpSource");
            _builder.Append(param0 + " ");
            _builder.Append(Version + " ");
            _builder.Append("%" + File + " ");
            _builder.Append(Source + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpSourceExtension(string Extension) {
            _builder.Append("%OpSourceExtension");
            _builder.Append(Extension + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpName(uint Target, string Name) {
            _builder.Append("%OpName");
            _builder.Append("%" + Target + " ");
            _builder.Append(Name + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberName(uint Type, uint Member, string Name) {
            _builder.Append("%OpMemberName");
            _builder.Append("%" + Type + " ");
            _builder.Append(Member + " ");
            _builder.Append(Name + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpString(uint returnId, string String) {
            _builder.Append("%OpString");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(String + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLine(uint File, uint Line, uint Column) {
            _builder.Append("%OpLine");
            _builder.Append("%" + File + " ");
            _builder.Append(Line + " ");
            _builder.Append(Column + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpExtension(string Name) {
            _builder.Append("%OpExtension");
            _builder.Append(Name + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExtInstImport(uint returnId, string Name) {
            _builder.Append("%OpExtInstImport");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(Name + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExtInst(uint returnId, uint param1, uint Set, uint Instruction, params uint[] Operand1Operand2) {
            _builder.Append("%OpExtInst");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Set + " ");
            _builder.Append(Instruction + " ");
            _builder.Append("%" + Operand1Operand2 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpMemoryModel(AddressingModel param0, MemoryModel param1) {
            _builder.Append("%OpMemoryModel");
            _builder.Append(param0 + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEntryPoint(ExecutionModel param0, uint EntryPoint, string Name, params uint[] Interface) {
            _builder.Append("%OpEntryPoint");
            _builder.Append(param0 + " ");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append(Name + " ");
            _builder.Append("%" + Interface + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecutionMode(uint EntryPoint, ExecutionMode Mode) {
            _builder.Append("%OpExecutionMode");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append(Mode + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpCapability(Capability Capability) {
            _builder.Append("%OpCapability");
            _builder.Append(Capability + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVoid(uint returnId) {
            _builder.Append("%OpTypeVoid");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeBool(uint returnId) {
            _builder.Append("%OpTypeBool");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeInt(uint returnId, uint Width, uint Signedness) {
            _builder.Append("%OpTypeInt");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(Width + " ");
            _builder.Append(Signedness + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeFloat(uint returnId, uint Width) {
            _builder.Append("%OpTypeFloat");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(Width + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVector(uint returnId, uint ComponentType, uint ComponentCount) {
            _builder.Append("%OpTypeVector");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ComponentType + " ");
            _builder.Append(ComponentCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeMatrix(uint returnId, uint ColumnType, uint ColumnCount) {
            _builder.Append("%OpTypeMatrix");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ColumnType + " ");
            _builder.Append(ColumnCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeImage(uint returnId, uint SampledType, Dim param2, uint Depth, uint Arrayed, uint MS, uint Sampled, ImageFormat param7, AccessQualifier? param8 = null) {
            _builder.Append("%OpTypeImage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + SampledType + " ");
            _builder.Append(param2 + " ");
            _builder.Append(Depth + " ");
            _builder.Append(Arrayed + " ");
            _builder.Append(MS + " ");
            _builder.Append(Sampled + " ");
            _builder.Append(param7 + " ");
            _builder.Append(param8 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeSampler(uint returnId) {
            _builder.Append("%OpTypeSampler");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeSampledImage(uint returnId, uint ImageType) {
            _builder.Append("%OpTypeSampledImage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ImageType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeArray(uint returnId, uint ElementType, uint Length) {
            _builder.Append("%OpTypeArray");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ElementType + " ");
            _builder.Append("%" + Length + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeRuntimeArray(uint returnId, uint ElementType) {
            _builder.Append("%OpTypeRuntimeArray");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ElementType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeStruct(uint returnId, params uint[] Member0typemember1type) {
            _builder.Append("%OpTypeStruct");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + Member0typemember1type + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeOpaque(uint returnId, string Thenameoftheopaquetype) {
            _builder.Append("%OpTypeOpaque");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(Thenameoftheopaquetype + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePointer(uint returnId, StorageClass param1, uint Type) {
            _builder.Append("%OpTypePointer");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(param1 + " ");
            _builder.Append("%" + Type + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeFunction(uint returnId, uint ReturnType, params uint[] Parameter0TypeParameter1Type) {
            _builder.Append("%OpTypeFunction");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ReturnType + " ");
            _builder.Append("%" + Parameter0TypeParameter1Type + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeEvent(uint returnId) {
            _builder.Append("%OpTypeEvent");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeDeviceEvent(uint returnId) {
            _builder.Append("%OpTypeDeviceEvent");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeReserveId(uint returnId) {
            _builder.Append("%OpTypeReserveId");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeQueue(uint returnId) {
            _builder.Append("%OpTypeQueue");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePipe(uint returnId, AccessQualifier Qualifier) {
            _builder.Append("%OpTypePipe");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append(Qualifier + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeForwardPointer(uint PointerType, StorageClass param1) {
            _builder.Append("%OpTypeForwardPointer");
            _builder.Append("%" + PointerType + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantTrue(uint returnId, uint param1) {
            _builder.Append("%OpConstantTrue");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantFalse(uint returnId, uint param1) {
            _builder.Append("%OpConstantFalse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstant(uint returnId, uint param1, double Value) {
            _builder.Append("%OpConstant");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantComposite(uint returnId, uint param1, params uint[] Constituents) {
            _builder.Append("%OpConstantComposite");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Constituents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantSampler(uint returnId, uint param1, SamplerAddressingMode param2, uint Param, SamplerFilterMode param4) {
            _builder.Append("%OpConstantSampler");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(param2 + " ");
            _builder.Append(Param + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantNull(uint returnId, uint param1) {
            _builder.Append("%OpConstantNull");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantTrue(uint returnId, uint param1) {
            _builder.Append("%OpSpecConstantTrue");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantFalse(uint returnId, uint param1) {
            _builder.Append("%OpSpecConstantFalse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstant(uint returnId, uint param1, double Value) {
            _builder.Append("%OpSpecConstant");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantComposite(uint returnId, uint param1, params uint[] Constituents) {
            _builder.Append("%OpSpecConstantComposite");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Constituents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantOp(uint returnId, uint param1, uint Opcode) {
            _builder.Append("%OpSpecConstantOp");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(Opcode + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunction(uint returnId, uint param1, FunctionControl param2, uint FunctionType) {
            _builder.Append("%OpFunction");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(param2 + " ");
            _builder.Append("%" + FunctionType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionParameter(uint returnId, uint param1) {
            _builder.Append("%OpFunctionParameter");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpFunctionEnd() {
            _builder.Append("%OpFunctionEnd");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionCall(uint returnId, uint param1, uint Function, params uint[] Argument0Argument1) {
            _builder.Append("%OpFunctionCall");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Function + " ");
            _builder.Append("%" + Argument0Argument1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVariable(uint returnId, uint param1, StorageClass param2, uint? Initializer = null) {
            _builder.Append("%OpVariable");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(param2 + " ");
            _builder.Append("%" + Initializer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageTexelPointer(uint returnId, uint param1, uint Image, uint Coordinate, uint Sample) {
            _builder.Append("%OpImageTexelPointer");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Sample + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoad(uint returnId, uint param1, uint Pointer, MemoryAccess? param3 = null) {
            _builder.Append("%OpLoad");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(param3 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpStore(uint Pointer, uint Object, MemoryAccess? param2 = null) {
            _builder.Append("%OpStore");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Object + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyMemory(uint Target, uint Source, MemoryAccess? param2 = null, MemoryAccess? param3 = null) {
            _builder.Append("%OpCopyMemory");
            _builder.Append("%" + Target + " ");
            _builder.Append("%" + Source + " ");
            _builder.Append(param2 + " ");
            _builder.Append(param3 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyMemorySized(uint Target, uint Source, uint Size, MemoryAccess? param3 = null, MemoryAccess? param4 = null) {
            _builder.Append("%OpCopyMemorySized");
            _builder.Append("%" + Target + " ");
            _builder.Append("%" + Source + " ");
            _builder.Append("%" + Size + " ");
            _builder.Append(param3 + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAccessChain(uint returnId, uint param1, uint Base, params uint[] Indexes) {
            _builder.Append("%OpAccessChain");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpInBoundsAccessChain(uint returnId, uint param1, uint Base, params uint[] Indexes) {
            _builder.Append("%OpInBoundsAccessChain");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrAccessChain(uint returnId, uint param1, uint Base, uint Element, params uint[] Indexes) {
            _builder.Append("%OpPtrAccessChain");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Element + " ");
            _builder.Append("%" + Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpArrayLength(uint returnId, uint param1, uint Structure, uint Arraymember) {
            _builder.Append("%OpArrayLength");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Structure + " ");
            _builder.Append(Arraymember + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericPtrMemSemantics(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpGenericPtrMemSemantics");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpInBoundsPtrAccessChain(uint returnId, uint param1, uint Base, uint Element, params uint[] Indexes) {
            _builder.Append("%OpInBoundsPtrAccessChain");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Element + " ");
            _builder.Append("%" + Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorate(uint Target, Decoration param1) {
            _builder.Append("%OpDecorate");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorate(uint StructureType, uint Member, Decoration param2) {
            _builder.Append("%OpMemberDecorate");
            _builder.Append("%" + StructureType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorationGroup(uint returnId) {
            _builder.Append("%OpDecorationGroup");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupDecorate(uint DecorationGroup, params uint[] Targets) {
            _builder.Append("%OpGroupDecorate");
            _builder.Append("%" + DecorationGroup + " ");
            _builder.Append("%" + Targets + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupMemberDecorate(uint DecorationGroup, params PairIdRefLiteralInteger[] Targets) {
            _builder.Append("%OpGroupMemberDecorate");
            _builder.Append("%" + DecorationGroup + " ");
            _builder.Append("%" + Targets.base0 + " ");
            _builder.Append(Targets.base1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorExtractDynamic(uint returnId, uint param1, uint Vector, uint Index) {
            _builder.Append("%OpVectorExtractDynamic");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorInsertDynamic(uint returnId, uint param1, uint Vector, uint Component, uint Index) {
            _builder.Append("%OpVectorInsertDynamic");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Component + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorShuffle(uint returnId, uint param1, uint Vector1, uint Vector2, params uint[] Components) {
            _builder.Append("%OpVectorShuffle");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            _builder.Append(Components + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeConstruct(uint returnId, uint param1, params uint[] Constituents) {
            _builder.Append("%OpCompositeConstruct");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Constituents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeExtract(uint returnId, uint param1, uint Composite, params uint[] Indexes) {
            _builder.Append("%OpCompositeExtract");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Composite + " ");
            _builder.Append(Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeInsert(uint returnId, uint param1, uint Object, uint Composite, params uint[] Indexes) {
            _builder.Append("%OpCompositeInsert");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Object + " ");
            _builder.Append("%" + Composite + " ");
            _builder.Append(Indexes + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyObject(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpCopyObject");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTranspose(uint returnId, uint param1, uint Matrix) {
            _builder.Append("%OpTranspose");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSampledImage(uint returnId, uint param1, uint Image, uint Sampler) {
            _builder.Append("%OpSampledImage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Sampler + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSampleImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%OpImageSampleExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleDrefImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSampleDrefImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleDrefExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%OpImageSampleDrefExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSampleProjImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%OpImageSampleProjExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjDrefImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSampleProjDrefImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjDrefExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%OpImageSampleProjDrefExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageFetch(uint returnId, uint param1, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageFetch");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageGather(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint Component, ImageOperands? param5 = null) {
            _builder.Append("%OpImageGather");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Component + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageDrefGather(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageDrefGather");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageRead(uint returnId, uint param1, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageRead");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageWrite(uint Image, uint Coordinate, uint Texel, ImageOperands? param3 = null) {
            _builder.Append("%OpImageWrite");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Texel + " ");
            _builder.Append(param3 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImage(uint returnId, uint param1, uint SampledImage) {
            _builder.Append("%OpImage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryFormat(uint returnId, uint param1, uint Image) {
            _builder.Append("%OpImageQueryFormat");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryOrder(uint returnId, uint param1, uint Image) {
            _builder.Append("%OpImageQueryOrder");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySizeLod(uint returnId, uint param1, uint Image, uint LevelofDetail) {
            _builder.Append("%OpImageQuerySizeLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + LevelofDetail + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySize(uint returnId, uint param1, uint Image) {
            _builder.Append("%OpImageQuerySize");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryLod(uint returnId, uint param1, uint SampledImage, uint Coordinate) {
            _builder.Append("%OpImageQueryLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryLevels(uint returnId, uint param1, uint Image) {
            _builder.Append("%OpImageQueryLevels");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySamples(uint returnId, uint param1, uint Image) {
            _builder.Append("%OpImageQuerySamples");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertFToU(uint returnId, uint param1, uint FloatValue) {
            _builder.Append("%OpConvertFToU");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertFToS(uint returnId, uint param1, uint FloatValue) {
            _builder.Append("%OpConvertFToS");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertSToF(uint returnId, uint param1, uint SignedValue) {
            _builder.Append("%OpConvertSToF");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToF(uint returnId, uint param1, uint UnsignedValue) {
            _builder.Append("%OpConvertUToF");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUConvert(uint returnId, uint param1, uint UnsignedValue) {
            _builder.Append("%OpUConvert");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSConvert(uint returnId, uint param1, uint SignedValue) {
            _builder.Append("%OpSConvert");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFConvert(uint returnId, uint param1, uint FloatValue) {
            _builder.Append("%OpFConvert");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpQuantizeToF16(uint returnId, uint param1, uint Value) {
            _builder.Append("%OpQuantizeToF16");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertPtrToU(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpConvertPtrToU");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSatConvertSToU(uint returnId, uint param1, uint SignedValue) {
            _builder.Append("%OpSatConvertSToU");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSatConvertUToS(uint returnId, uint param1, uint UnsignedValue) {
            _builder.Append("%OpSatConvertUToS");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToPtr(uint returnId, uint param1, uint IntegerValue) {
            _builder.Append("%OpConvertUToPtr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + IntegerValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrCastToGeneric(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpPtrCastToGeneric");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericCastToPtr(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpGenericCastToPtr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericCastToPtrExplicit(uint returnId, uint param1, uint Pointer, StorageClass Storage) {
            _builder.Append("%OpGenericCastToPtrExplicit");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Storage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitcast(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpBitcast");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSNegate(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpSNegate");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFNegate(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpFNegate");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAdd(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFAdd(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISub(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpISub");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFSub(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFSub");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIMul(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIMul");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFMul(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFMul");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUDiv(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUDiv");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSDiv(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSDiv");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFDiv(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFDiv");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMod(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUMod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSRem(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSRem");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSMod(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSMod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFRem(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFRem");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFMod(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFMod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorTimesScalar(uint returnId, uint param1, uint Vector, uint Scalar) {
            _builder.Append("%OpVectorTimesScalar");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Scalar + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesScalar(uint returnId, uint param1, uint Matrix, uint Scalar) {
            _builder.Append("%OpMatrixTimesScalar");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.Append("%" + Scalar + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorTimesMatrix(uint returnId, uint param1, uint Vector, uint Matrix) {
            _builder.Append("%OpVectorTimesMatrix");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesVector(uint returnId, uint param1, uint Matrix, uint Vector) {
            _builder.Append("%OpMatrixTimesVector");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesMatrix(uint returnId, uint param1, uint LeftMatrix, uint RightMatrix) {
            _builder.Append("%OpMatrixTimesMatrix");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + LeftMatrix + " ");
            _builder.Append("%" + RightMatrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpOuterProduct(uint returnId, uint param1, uint Vector1, uint Vector2) {
            _builder.Append("%OpOuterProduct");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDot(uint returnId, uint param1, uint Vector1, uint Vector2) {
            _builder.Append("%OpDot");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAddCarry(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIAddCarry");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISubBorrow(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpISubBorrow");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMulExtended(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUMulExtended");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSMulExtended(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSMulExtended");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAny(uint returnId, uint param1, uint Vector) {
            _builder.Append("%OpAny");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAll(uint returnId, uint param1, uint Vector) {
            _builder.Append("%OpAll");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsNan(uint returnId, uint param1, uint x) {
            _builder.Append("%OpIsNan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsInf(uint returnId, uint param1, uint x) {
            _builder.Append("%OpIsInf");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsFinite(uint returnId, uint param1, uint x) {
            _builder.Append("%OpIsFinite");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsNormal(uint returnId, uint param1, uint x) {
            _builder.Append("%OpIsNormal");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSignBitSet(uint returnId, uint param1, uint x) {
            _builder.Append("%OpSignBitSet");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLessOrGreater(uint returnId, uint param1, uint x, uint y) {
            _builder.Append("%OpLessOrGreater");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpOrdered(uint returnId, uint param1, uint x, uint y) {
            _builder.Append("%OpOrdered");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUnordered(uint returnId, uint param1, uint x, uint y) {
            _builder.Append("%OpUnordered");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpLogicalEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalNotEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpLogicalNotEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalOr(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpLogicalOr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalAnd(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpLogicalAnd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalNot(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpLogicalNot");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSelect(uint returnId, uint param1, uint Condition, uint Object1, uint Object2) {
            _builder.Append("%OpSelect");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Condition + " ");
            _builder.Append("%" + Object1 + " ");
            _builder.Append("%" + Object2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpINotEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpINotEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUGreaterThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUGreaterThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSGreaterThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSGreaterThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUGreaterThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUGreaterThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSGreaterThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSGreaterThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpULessThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpULessThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSLessThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSLessThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpULessThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpULessThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSLessThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpSLessThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdNotEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdNotEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordNotEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordNotEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdLessThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdLessThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordLessThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordLessThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdGreaterThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdGreaterThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordGreaterThan(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordGreaterThan");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdLessThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdLessThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordLessThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordLessThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdGreaterThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFOrdGreaterThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordGreaterThanEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpFUnordGreaterThanEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftRightLogical(uint returnId, uint param1, uint Base, uint Shift) {
            _builder.Append("%OpShiftRightLogical");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftRightArithmetic(uint returnId, uint param1, uint Base, uint Shift) {
            _builder.Append("%OpShiftRightArithmetic");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftLeftLogical(uint returnId, uint param1, uint Base, uint Shift) {
            _builder.Append("%OpShiftLeftLogical");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseOr(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpBitwiseOr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseXor(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpBitwiseXor");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseAnd(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpBitwiseAnd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpNot(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpNot");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldInsert(uint returnId, uint param1, uint Base, uint Insert, uint Offset, uint Count) {
            _builder.Append("%OpBitFieldInsert");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Insert + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldSExtract(uint returnId, uint param1, uint Base, uint Offset, uint Count) {
            _builder.Append("%OpBitFieldSExtract");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldUExtract(uint returnId, uint param1, uint Base, uint Offset, uint Count) {
            _builder.Append("%OpBitFieldUExtract");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitReverse(uint returnId, uint param1, uint Base) {
            _builder.Append("%OpBitReverse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitCount(uint returnId, uint param1, uint Base) {
            _builder.Append("%OpBitCount");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Base + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdx(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdx");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdy(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdy");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidth(uint returnId, uint param1, uint P) {
            _builder.Append("%OpFwidth");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdxFine(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdxFine");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdyFine(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdyFine");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidthFine(uint returnId, uint param1, uint P) {
            _builder.Append("%OpFwidthFine");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdxCoarse(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdxCoarse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdyCoarse(uint returnId, uint param1, uint P) {
            _builder.Append("%OpDPdyCoarse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidthCoarse(uint returnId, uint param1, uint P) {
            _builder.Append("%OpFwidthCoarse");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpEmitVertex() {
            _builder.Append("%OpEmitVertex");
            _builder.AppendLine();
        }
        
        public void GenerateOpEndPrimitive() {
            _builder.Append("%OpEndPrimitive");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEmitStreamVertex(uint Stream) {
            _builder.Append("%OpEmitStreamVertex");
            _builder.Append("%" + Stream + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEndStreamPrimitive(uint Stream) {
            _builder.Append("%OpEndStreamPrimitive");
            _builder.Append("%" + Stream + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpControlBarrier(uint Execution, uint Memory, uint Semantics) {
            _builder.Append("%OpControlBarrier");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemoryBarrier(uint Memory, uint Semantics) {
            _builder.Append("%OpMemoryBarrier");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicLoad(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%OpAtomicLoad");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicStore(uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicStore");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicExchange(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicExchange");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicCompareExchange(uint returnId, uint param1, uint Pointer, uint Memory, uint Equal, uint Unequal, uint Value, uint Comparator) {
            _builder.Append("%OpAtomicCompareExchange");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Equal + " ");
            _builder.Append("%" + Unequal + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Comparator + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicCompareExchangeWeak(uint returnId, uint param1, uint Pointer, uint Memory, uint Equal, uint Unequal, uint Value, uint Comparator) {
            _builder.Append("%OpAtomicCompareExchangeWeak");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Equal + " ");
            _builder.Append("%" + Unequal + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Comparator + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIIncrement(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%OpAtomicIIncrement");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIDecrement(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%OpAtomicIDecrement");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIAdd(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicIAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicISub(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicISub");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicSMin(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicSMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicUMin(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicUMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicSMax(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicSMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicUMax(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicUMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicAnd(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicAnd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicOr(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicOr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicXor(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicXor");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPhi(uint returnId, uint param1, params PairIdRefIdRef[] VariableParent) {
            _builder.Append("%OpPhi");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + VariableParent.base0 + " ");
            _builder.Append("%" + VariableParent.base1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoopMerge(uint MergeBlock, uint ContinueTarget, LoopControl param2) {
            _builder.Append("%OpLoopMerge");
            _builder.Append("%" + MergeBlock + " ");
            _builder.Append("%" + ContinueTarget + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSelectionMerge(uint MergeBlock, SelectionControl param1) {
            _builder.Append("%OpSelectionMerge");
            _builder.Append("%" + MergeBlock + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLabel(uint returnId) {
            _builder.Append("%OpLabel");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBranch(uint TargetLabel) {
            _builder.Append("%OpBranch");
            _builder.Append("%" + TargetLabel + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBranchConditional(uint Condition, uint TrueLabel, uint FalseLabel, params uint[] Branchweights) {
            _builder.Append("%OpBranchConditional");
            _builder.Append("%" + Condition + " ");
            _builder.Append("%" + TrueLabel + " ");
            _builder.Append("%" + FalseLabel + " ");
            _builder.Append(Branchweights + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSwitch(uint Selector, uint Default, params PairLiteralIntegerIdRef[] Target) {
            _builder.Append("%OpSwitch");
            _builder.Append("%" + Selector + " ");
            _builder.Append("%" + Default + " ");
            _builder.Append(Target.base0 + " ");
            _builder.Append("%" + Target.base1 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpKill() {
            _builder.Append("%OpKill");
            _builder.AppendLine();
        }
        
        public void GenerateOpReturn() {
            _builder.Append("%OpReturn");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReturnValue(uint Value) {
            _builder.Append("%OpReturnValue");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpUnreachable() {
            _builder.Append("%OpUnreachable");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLifetimeStart(uint Pointer, uint Size) {
            _builder.Append("%OpLifetimeStart");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Size + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLifetimeStop(uint Pointer, uint Size) {
            _builder.Append("%OpLifetimeStop");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Size + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAsyncCopy(uint returnId, uint param1, uint Execution, uint Destination, uint Source, uint NumElements, uint Stride, uint Event) {
            _builder.Append("%OpGroupAsyncCopy");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Destination + " ");
            _builder.Append("%" + Source + " ");
            _builder.Append("%" + NumElements + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupWaitEvents(uint Execution, uint NumEvents, uint EventsList) {
            _builder.Append("%OpGroupWaitEvents");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + EventsList + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAll(uint returnId, uint param1, uint Execution, uint Predicate) {
            _builder.Append("%OpGroupAll");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAny(uint returnId, uint param1, uint Execution, uint Predicate) {
            _builder.Append("%OpGroupAny");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupBroadcast(uint returnId, uint param1, uint Execution, uint Value, uint LocalId) {
            _builder.Append("%OpGroupBroadcast");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + LocalId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupIAdd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupIAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFAdd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupUMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupSMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupUMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupSMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadPipe(uint returnId, uint param1, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReadPipe");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePipe(uint returnId, uint param1, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpWritePipe");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReservedReadPipe(uint returnId, uint param1, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReservedReadPipe");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + Index + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReservedWritePipe(uint returnId, uint param1, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReservedWritePipe");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + Index + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReserveReadPipePackets(uint returnId, uint param1, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReserveReadPipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReserveWritePipePackets(uint returnId, uint param1, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReserveWritePipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCommitReadPipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpCommitReadPipe");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCommitWritePipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpCommitWritePipe");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsValidReserveId(uint returnId, uint param1, uint ReserveId) {
            _builder.Append("%OpIsValidReserveId");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetNumPipePackets(uint returnId, uint param1, uint Pipe, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGetNumPipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetMaxPipePackets(uint returnId, uint param1, uint Pipe, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGetMaxPipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupReserveReadPipePackets(uint returnId, uint param1, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGroupReserveReadPipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupReserveWritePipePackets(uint returnId, uint param1, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGroupReserveWritePipePackets");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupCommitReadPipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGroupCommitReadPipe");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupCommitWritePipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpGroupCommitWritePipe");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEnqueueMarker(uint returnId, uint param1, uint Queue, uint NumEvents, uint WaitEvents, uint RetEvent) {
            _builder.Append("%OpEnqueueMarker");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Queue + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + WaitEvents + " ");
            _builder.Append("%" + RetEvent + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEnqueueKernel(uint returnId, uint param1, uint Queue, uint Flags, uint NDRange, uint NumEvents, uint WaitEvents, uint RetEvent, uint Invoke, uint Param, uint ParamSize, uint ParamAlign, params uint[] LocalSize) {
            _builder.Append("%OpEnqueueKernel");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Queue + " ");
            _builder.Append("%" + Flags + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + WaitEvents + " ");
            _builder.Append("%" + RetEvent + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.Append("%" + LocalSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelNDrangeSubGroupCount(uint returnId, uint param1, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelNDrangeSubGroupCount");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelNDrangeMaxSubGroupSize(uint returnId, uint param1, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelNDrangeMaxSubGroupSize");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelWorkGroupSize(uint returnId, uint param1, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelWorkGroupSize");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelPreferredWorkGroupSizeMultiple(uint returnId, uint param1, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelPreferredWorkGroupSizeMultiple");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRetainEvent(uint Event) {
            _builder.Append("%OpRetainEvent");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReleaseEvent(uint Event) {
            _builder.Append("%OpReleaseEvent");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCreateUserEvent(uint returnId, uint param1) {
            _builder.Append("%OpCreateUserEvent");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsValidEvent(uint returnId, uint param1, uint Event) {
            _builder.Append("%OpIsValidEvent");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSetUserEventStatus(uint Event, uint Status) {
            _builder.Append("%OpSetUserEventStatus");
            _builder.Append("%" + Event + " ");
            _builder.Append("%" + Status + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCaptureEventProfilingInfo(uint Event, uint ProfilingInfo, uint Value) {
            _builder.Append("%OpCaptureEventProfilingInfo");
            _builder.Append("%" + Event + " ");
            _builder.Append("%" + ProfilingInfo + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetDefaultQueue(uint returnId, uint param1) {
            _builder.Append("%OpGetDefaultQueue");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBuildNDRange(uint returnId, uint param1, uint GlobalWorkSize, uint LocalWorkSize, uint GlobalWorkOffset) {
            _builder.Append("%OpBuildNDRange");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + GlobalWorkSize + " ");
            _builder.Append("%" + LocalWorkSize + " ");
            _builder.Append("%" + GlobalWorkOffset + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSparseSampleImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%OpImageSparseSampleExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleDrefImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSparseSampleDrefImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleDrefExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%OpImageSparseSampleDrefExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSparseSampleProjImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%OpImageSparseSampleProjExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjDrefImplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSparseSampleProjDrefImplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjDrefExplicitLod(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%OpImageSparseSampleProjDrefExplicitLod");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseFetch(uint returnId, uint param1, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSparseFetch");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseGather(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint Component, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSparseGather");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Component + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseDrefGather(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%OpImageSparseDrefGather");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseTexelsResident(uint returnId, uint param1, uint ResidentCode) {
            _builder.Append("%OpImageSparseTexelsResident");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ResidentCode + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpNoLine() {
            _builder.Append("%OpNoLine");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFlagTestAndSet(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%OpAtomicFlagTestAndSet");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFlagClear(uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%OpAtomicFlagClear");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseRead(uint returnId, uint param1, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%OpImageSparseRead");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSizeOf(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpSizeOf");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePipeStorage(uint returnId) {
            _builder.Append("%OpTypePipeStorage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantPipeStorage(uint returnId, uint param1, uint PacketSize, uint PacketAlignment, uint Capacity) {
            _builder.Append("%OpConstantPipeStorage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(PacketSize + " ");
            _builder.Append(PacketAlignment + " ");
            _builder.Append(Capacity + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCreatePipeFromPipeStorage(uint returnId, uint param1, uint PipeStorage) {
            _builder.Append("%OpCreatePipeFromPipeStorage");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PipeStorage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelLocalSizeForSubgroupCount(uint returnId, uint param1, uint SubgroupCount, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelLocalSizeForSubgroupCount");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SubgroupCount + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelMaxNumSubgroups(uint returnId, uint param1, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%OpGetKernelMaxNumSubgroups");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeNamedBarrier(uint returnId) {
            _builder.Append("%OpTypeNamedBarrier");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpNamedBarrierInitialize(uint returnId, uint param1, uint SubgroupCount) {
            _builder.Append("%OpNamedBarrierInitialize");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SubgroupCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemoryNamedBarrier(uint NamedBarrier, uint Memory, uint Semantics) {
            _builder.Append("%OpMemoryNamedBarrier");
            _builder.Append("%" + NamedBarrier + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpModuleProcessed(string Process) {
            _builder.Append("%OpModuleProcessed");
            _builder.Append(Process + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecutionModeId(uint EntryPoint, ExecutionMode Mode) {
            _builder.Append("%OpExecutionModeId");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append(Mode + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateId(uint Target, Decoration param1) {
            _builder.Append("%OpDecorateId");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformElect(uint returnId, uint param1, uint Execution) {
            _builder.Append("%OpGroupNonUniformElect");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAll(uint returnId, uint param1, uint Execution, uint Predicate) {
            _builder.Append("%OpGroupNonUniformAll");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAny(uint returnId, uint param1, uint Execution, uint Predicate) {
            _builder.Append("%OpGroupNonUniformAny");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAllEqual(uint returnId, uint param1, uint Execution, uint Value) {
            _builder.Append("%OpGroupNonUniformAllEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBroadcast(uint returnId, uint param1, uint Execution, uint Value, uint Id) {
            _builder.Append("%OpGroupNonUniformBroadcast");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Id + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBroadcastFirst(uint returnId, uint param1, uint Execution, uint Value) {
            _builder.Append("%OpGroupNonUniformBroadcastFirst");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallot(uint returnId, uint param1, uint Execution, uint Predicate) {
            _builder.Append("%OpGroupNonUniformBallot");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformInverseBallot(uint returnId, uint param1, uint Execution, uint Value) {
            _builder.Append("%OpGroupNonUniformInverseBallot");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotBitExtract(uint returnId, uint param1, uint Execution, uint Value, uint Index) {
            _builder.Append("%OpGroupNonUniformBallotBitExtract");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotBitCount(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value) {
            _builder.Append("%OpGroupNonUniformBallotBitCount");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotFindLSB(uint returnId, uint param1, uint Execution, uint Value) {
            _builder.Append("%OpGroupNonUniformBallotFindLSB");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotFindMSB(uint returnId, uint param1, uint Execution, uint Value) {
            _builder.Append("%OpGroupNonUniformBallotFindMSB");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffle(uint returnId, uint param1, uint Execution, uint Value, uint Id) {
            _builder.Append("%OpGroupNonUniformShuffle");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Id + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleXor(uint returnId, uint param1, uint Execution, uint Value, uint Mask) {
            _builder.Append("%OpGroupNonUniformShuffleXor");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Mask + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleUp(uint returnId, uint param1, uint Execution, uint Value, uint Delta) {
            _builder.Append("%OpGroupNonUniformShuffleUp");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleDown(uint returnId, uint param1, uint Execution, uint Value, uint Delta) {
            _builder.Append("%OpGroupNonUniformShuffleDown");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformIAdd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformIAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFAdd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformFAdd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformIMul(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformIMul");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMul(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformFMul");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformSMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformSMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformUMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformUMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMin(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformFMin");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformSMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformSMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformUMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformUMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMax(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformFMax");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseAnd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformBitwiseAnd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseOr(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformBitwiseOr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseXor(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformBitwiseXor");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalAnd(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformLogicalAnd");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalOr(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformLogicalOr");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalXor(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%OpGroupNonUniformLogicalXor");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + ClusterSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformQuadBroadcast(uint returnId, uint param1, uint Execution, uint Value, uint Index) {
            _builder.Append("%OpGroupNonUniformQuadBroadcast");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformQuadSwap(uint returnId, uint param1, uint Execution, uint Value, uint Direction) {
            _builder.Append("%OpGroupNonUniformQuadSwap");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyLogical(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpCopyLogical");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpPtrEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrNotEqual(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpPtrNotEqual");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrDiff(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpPtrDiff");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateInvocation() {
            _builder.Append("%OpTerminateInvocation");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBallotKHR(uint returnId, uint param1, uint Predicate) {
            _builder.Append("%OpSubgroupBallotKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupFirstInvocationKHR(uint returnId, uint param1, uint Value) {
            _builder.Append("%OpSubgroupFirstInvocationKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAllKHR(uint returnId, uint param1, uint Predicate) {
            _builder.Append("%OpSubgroupAllKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAnyKHR(uint returnId, uint param1, uint Predicate) {
            _builder.Append("%OpSubgroupAnyKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAllEqualKHR(uint returnId, uint param1, uint Predicate) {
            _builder.Append("%OpSubgroupAllEqualKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupReadInvocationKHR(uint returnId, uint param1, uint Value, uint Index) {
            _builder.Append("%OpSubgroupReadInvocationKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTraceRayKHR(uint Accel, uint RayFlags, uint CullMask, uint SBTOffset, uint SBTStride, uint MissIndex, uint RayOrigin, uint RayTmin, uint RayDirection, uint RayTmax, uint Payload) {
            _builder.Append("%OpTraceRayKHR");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + SBTOffset + " ");
            _builder.Append("%" + SBTStride + " ");
            _builder.Append("%" + MissIndex + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTmin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTmax + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecuteCallableKHR(uint SBTIndex, uint CallableData) {
            _builder.Append("%OpExecuteCallableKHR");
            _builder.Append("%" + SBTIndex + " ");
            _builder.Append("%" + CallableData + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToAccelerationStructureKHR(uint returnId, uint param1, uint Accel) {
            _builder.Append("%OpConvertUToAccelerationStructureKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Accel + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpIgnoreIntersectionKHR() {
            _builder.Append("%OpIgnoreIntersectionKHR");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateRayKHR() {
            _builder.Append("%OpTerminateRayKHR");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeRayQueryKHR(uint returnId) {
            _builder.Append("%OpTypeRayQueryKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryInitializeKHR(uint RayQuery, uint Accel, uint RayFlags, uint CullMask, uint RayOrigin, uint RayTMin, uint RayDirection, uint RayTMax) {
            _builder.Append("%OpRayQueryInitializeKHR");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTMin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTMax + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryTerminateKHR(uint RayQuery) {
            _builder.Append("%OpRayQueryTerminateKHR");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGenerateIntersectionKHR(uint RayQuery, uint HitT) {
            _builder.Append("%OpRayQueryGenerateIntersectionKHR");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + HitT + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryConfirmIntersectionKHR(uint RayQuery) {
            _builder.Append("%OpRayQueryConfirmIntersectionKHR");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryProceedKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryProceedKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionTypeKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionTypeKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupIAddNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupIAddNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFAddNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFAddNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMinNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFMinNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMinNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupUMinNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMinNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupSMinNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMaxNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupFMaxNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMaxNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupUMaxNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMaxNonUniformAMD(uint returnId, uint param1, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%OpGroupSMaxNonUniformAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFragmentMaskFetchAMD(uint returnId, uint param1, uint Image, uint Coordinate) {
            _builder.Append("%OpFragmentMaskFetchAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFragmentFetchAMD(uint returnId, uint param1, uint Image, uint Coordinate, uint FragmentIndex) {
            _builder.Append("%OpFragmentFetchAMD");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + FragmentIndex + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadClockKHR(uint returnId, uint param1, uint Execution) {
            _builder.Append("%OpReadClockKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Execution + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleFootprintNV(uint returnId, uint param1, uint SampledImage, uint Coordinate, uint Granularity, uint Coarse, ImageOperands? param6 = null) {
            _builder.Append("%OpImageSampleFootprintNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Granularity + " ");
            _builder.Append("%" + Coarse + " ");
            _builder.Append(param6 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformPartitionNV(uint returnId, uint param1, uint Value) {
            _builder.Append("%OpGroupNonUniformPartitionNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePackedPrimitiveIndices4x8NV(uint IndexOffset, uint PackedIndices) {
            _builder.Append("%OpWritePackedPrimitiveIndices4x8NV");
            _builder.Append("%" + IndexOffset + " ");
            _builder.Append("%" + PackedIndices + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReportIntersectionNV(uint returnId, uint param1, uint Hit, uint HitKind) {
            _builder.Append("%OpReportIntersectionNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Hit + " ");
            _builder.Append("%" + HitKind + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReportIntersectionKHR(uint returnId, uint param1, uint Hit, uint HitKind) {
            _builder.Append("%OpReportIntersectionKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Hit + " ");
            _builder.Append("%" + HitKind + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpIgnoreIntersectionNV() {
            _builder.Append("%OpIgnoreIntersectionNV");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateRayNV() {
            _builder.Append("%OpTerminateRayNV");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTraceNV(uint Accel, uint RayFlags, uint CullMask, uint SBTOffset, uint SBTStride, uint MissIndex, uint RayOrigin, uint RayTmin, uint RayDirection, uint RayTmax, uint PayloadId) {
            _builder.Append("%OpTraceNV");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + SBTOffset + " ");
            _builder.Append("%" + SBTStride + " ");
            _builder.Append("%" + MissIndex + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTmin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTmax + " ");
            _builder.Append("%" + PayloadId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAccelerationStructureNV(uint returnId) {
            _builder.Append("%OpTypeAccelerationStructureNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAccelerationStructureKHR(uint returnId) {
            _builder.Append("%OpTypeAccelerationStructureKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecuteCallableNV(uint SBTIndex, uint CallableDataId) {
            _builder.Append("%OpExecuteCallableNV");
            _builder.Append("%" + SBTIndex + " ");
            _builder.Append("%" + CallableDataId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeCooperativeMatrixNV(uint returnId, uint ComponentType, uint Execution, uint Rows, uint Columns) {
            _builder.Append("%OpTypeCooperativeMatrixNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ComponentType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Rows + " ");
            _builder.Append("%" + Columns + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixLoadNV(uint returnId, uint param1, uint Pointer, uint Stride, uint ColumnMajor, MemoryAccess? param5 = null) {
            _builder.Append("%OpCooperativeMatrixLoadNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + ColumnMajor + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixStoreNV(uint Pointer, uint Object, uint Stride, uint ColumnMajor, MemoryAccess? param4 = null) {
            _builder.Append("%OpCooperativeMatrixStoreNV");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Object + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + ColumnMajor + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixMulAddNV(uint returnId, uint param1, uint A, uint B, uint C) {
            _builder.Append("%OpCooperativeMatrixMulAddNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + A + " ");
            _builder.Append("%" + B + " ");
            _builder.Append("%" + C + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixLengthNV(uint returnId, uint param1, uint Type) {
            _builder.Append("%OpCooperativeMatrixLengthNV");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Type + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpBeginInvocationInterlockEXT() {
            _builder.Append("%OpBeginInvocationInterlockEXT");
            _builder.AppendLine();
        }
        
        public void GenerateOpEndInvocationInterlockEXT() {
            _builder.Append("%OpEndInvocationInterlockEXT");
            _builder.AppendLine();
        }
        
        public void GenerateOpDemoteToHelperInvocationEXT() {
            _builder.Append("%OpDemoteToHelperInvocationEXT");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsHelperInvocationEXT(uint returnId, uint param1) {
            _builder.Append("%OpIsHelperInvocationEXT");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleINTEL(uint returnId, uint param1, uint Data, uint InvocationId) {
            _builder.Append("%OpSubgroupShuffleINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Data + " ");
            _builder.Append("%" + InvocationId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleDownINTEL(uint returnId, uint param1, uint Current, uint Next, uint Delta) {
            _builder.Append("%OpSubgroupShuffleDownINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Current + " ");
            _builder.Append("%" + Next + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleUpINTEL(uint returnId, uint param1, uint Previous, uint Current, uint Delta) {
            _builder.Append("%OpSubgroupShuffleUpINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Previous + " ");
            _builder.Append("%" + Current + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleXorINTEL(uint returnId, uint param1, uint Data, uint Value) {
            _builder.Append("%OpSubgroupShuffleXorINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Data + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBlockReadINTEL(uint returnId, uint param1, uint Ptr) {
            _builder.Append("%OpSubgroupBlockReadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Ptr + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBlockWriteINTEL(uint Ptr, uint Data) {
            _builder.Append("%OpSubgroupBlockWriteINTEL");
            _builder.Append("%" + Ptr + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageBlockReadINTEL(uint returnId, uint param1, uint Image, uint Coordinate) {
            _builder.Append("%OpSubgroupImageBlockReadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageBlockWriteINTEL(uint Image, uint Coordinate, uint Data) {
            _builder.Append("%OpSubgroupImageBlockWriteINTEL");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageMediaBlockReadINTEL(uint returnId, uint param1, uint Image, uint Coordinate, uint Width, uint Height) {
            _builder.Append("%OpSubgroupImageMediaBlockReadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Width + " ");
            _builder.Append("%" + Height + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageMediaBlockWriteINTEL(uint Image, uint Coordinate, uint Width, uint Height, uint Data) {
            _builder.Append("%OpSubgroupImageMediaBlockWriteINTEL");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Width + " ");
            _builder.Append("%" + Height + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUCountLeadingZerosINTEL(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpUCountLeadingZerosINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUCountTrailingZerosINTEL(uint returnId, uint param1, uint Operand) {
            _builder.Append("%OpUCountTrailingZerosINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAbsISubINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpAbsISubINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAbsUSubINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpAbsUSubINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAddSatINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIAddSatINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAddSatINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUAddSatINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAverageINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIAverageINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAverageINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUAverageINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAverageRoundedINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIAverageRoundedINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAverageRoundedINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUAverageRoundedINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISubSatINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpISubSatINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUSubSatINTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUSubSatINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIMul32x16INTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpIMul32x16INTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMul32x16INTEL(uint returnId, uint param1, uint Operand1, uint Operand2) {
            _builder.Append("%OpUMul32x16INTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstFunctionPointerINTEL(uint returnId, uint param1, uint Function) {
            _builder.Append("%OpConstFunctionPointerINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Function + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionPointerCallINTEL(uint returnId, uint param1, params uint[] Operand1) {
            _builder.Append("%OpFunctionPointerCallINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmTargetINTEL(uint returnId, uint param1, string Asmtarget) {
            _builder.Append("%OpAsmTargetINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append(Asmtarget + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmINTEL(uint returnId, uint param1, uint Asmtype, uint Target, string Asminstructions, string Constraints) {
            _builder.Append("%OpAsmINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Asmtype + " ");
            _builder.Append("%" + Target + " ");
            _builder.Append(Asminstructions + " ");
            _builder.Append(Constraints + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmCallINTEL(uint returnId, uint param1, uint Asm, params uint[] Argument0) {
            _builder.Append("%OpAsmCallINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Asm + " ");
            _builder.Append("%" + Argument0 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFMinEXT(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicFMinEXT");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFMaxEXT(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicFMaxEXT");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateString(uint Target, Decoration param1) {
            _builder.Append("%OpDecorateString");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateStringGOOGLE(uint Target, Decoration param1) {
            _builder.Append("%OpDecorateStringGOOGLE");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorateString(uint StructType, uint Member, Decoration param2) {
            _builder.Append("%OpMemberDecorateString");
            _builder.Append("%" + StructType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorateStringGOOGLE(uint StructType, uint Member, Decoration param2) {
            _builder.Append("%OpMemberDecorateStringGOOGLE");
            _builder.Append("%" + StructType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVmeImageINTEL(uint returnId, uint param1, uint ImageType, uint Sampler) {
            _builder.Append("%OpVmeImageINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ImageType + " ");
            _builder.Append("%" + Sampler + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVmeImageINTEL(uint returnId, uint ImageType) {
            _builder.Append("%OpTypeVmeImageINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + ImageType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImePayloadINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcRefPayloadINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcRefPayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcSicPayloadINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcSicPayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcMcePayloadINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcMcePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcMceResultINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcMceResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImeResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultSingleReferenceStreamoutINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImeResultSingleReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultDualReferenceStreamoutINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImeResultDualReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeSingleReferenceStreaminINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImeSingleReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeDualReferenceStreaminINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcImeDualReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcRefResultINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcRefResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcSicResultINTEL(uint returnId) {
            _builder.Append("%OpTypeAvcSicResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL(uint returnId, uint param1, uint ReferenceBasePenalty, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ReferenceBasePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterShapePenaltyINTEL(uint returnId, uint param1, uint PackedShapePenalty, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetInterShapePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedShapePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterDirectionPenaltyINTEL(uint returnId, uint param1, uint DirectionCost, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetInterDirectionPenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + DirectionCost + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetMotionVectorCostFunctionINTEL(uint returnId, uint param1, uint PackedCostCenterDelta, uint PackedCostTable, uint CostPrecision, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedCostCenterDelta + " ");
            _builder.Append("%" + PackedCostTable + " ");
            _builder.Append("%" + CostPrecision + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL(uint returnId, uint param1, uint SliceType, uint Qp) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetAcOnlyHaarINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetAcOnlyHaarINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL(uint returnId, uint param1, uint SourceFieldPolarity, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SourceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL(uint returnId, uint param1, uint ReferenceFieldPolarity, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ReferenceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL(uint returnId, uint param1, uint ForwardReferenceFieldPolarity, uint BackwardReferenceFieldPolarity, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ForwardReferenceFieldPolarity + " ");
            _builder.Append("%" + BackwardReferenceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToImePayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToImePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToImeResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToImeResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToRefPayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToRefPayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToRefResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToRefResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToSicPayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToSicPayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToSicResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceConvertToSicResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetMotionVectorsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetMotionVectorsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterDistortionsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterDistortionsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetBestInterDistortionsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetBestInterDistortionsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMajorShapeINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterMajorShapeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMinorShapeINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterMinorShapeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterDirectionsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterDirectionsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMotionVectorCountINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterMotionVectorCountINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterReferenceIdsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterReferenceIdsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL(uint returnId, uint param1, uint PackedReferenceIds, uint PackedReferenceParameterFieldPolarities, uint Payload) {
            _builder.Append("%OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceParameterFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeInitializeINTEL(uint returnId, uint param1, uint SrcCoord, uint PartitionMask, uint SADAdjustment) {
            _builder.Append("%OpSubgroupAvcImeInitializeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + PartitionMask + " ");
            _builder.Append("%" + SADAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetSingleReferenceINTEL(uint returnId, uint param1, uint RefOffset, uint SearchWindowConfig, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetSingleReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RefOffset + " ");
            _builder.Append("%" + SearchWindowConfig + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetDualReferenceINTEL(uint returnId, uint param1, uint FwdRefOffset, uint BwdRefOffset, uint idSearchWindowConfig, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetDualReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + FwdRefOffset + " ");
            _builder.Append("%" + BwdRefOffset + " ");
            _builder.Append("%" + idSearchWindowConfig + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeRefWindowSizeINTEL(uint returnId, uint param1, uint SearchWindowConfig, uint DualRef) {
            _builder.Append("%OpSubgroupAvcImeRefWindowSizeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SearchWindowConfig + " ");
            _builder.Append("%" + DualRef + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeAdjustRefOffsetINTEL(uint returnId, uint param1, uint RefOffset, uint SrcCoord, uint RefWindowSize, uint ImageSize) {
            _builder.Append("%OpSubgroupAvcImeAdjustRefOffsetINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RefOffset + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + RefWindowSize + " ");
            _builder.Append("%" + ImageSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeConvertToMcePayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeConvertToMcePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetMaxMotionVectorCountINTEL(uint returnId, uint param1, uint MaxMotionVectorCount, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetMaxMotionVectorCountINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + MaxMotionVectorCount + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetUnidirectionalMixDisableINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL(uint returnId, uint param1, uint Threshold, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Threshold + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetWeightedSadINTEL(uint returnId, uint param1, uint PackedSadWeights, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeSetWeightedSadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedSadWeights + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithDualReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeConvertToMceResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeConvertToMceResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetSingleReferenceStreaminINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetSingleReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetDualReferenceStreaminINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetDualReferenceStreaminINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeStripSingleReferenceStreamoutINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeStripDualReferenceStreamoutINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeStripDualReferenceStreamoutINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL(uint returnId, uint param1, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetBorderReachedINTEL(uint returnId, uint param1, uint ImageSelect, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetBorderReachedINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ImageSelect + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetTruncatedSearchIndicationINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcFmeInitializeINTEL(uint returnId, uint param1, uint SrcCoord, uint MotionVectors, uint MajorShapes, uint MinorShapes, uint Direction, uint PixelResolution, uint SadAdjustment) {
            _builder.Append("%OpSubgroupAvcFmeInitializeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + MajorShapes + " ");
            _builder.Append("%" + MinorShapes + " ");
            _builder.Append("%" + Direction + " ");
            _builder.Append("%" + PixelResolution + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcBmeInitializeINTEL(uint returnId, uint param1, uint SrcCoord, uint MotionVectors, uint MajorShapes, uint MinorShapes, uint Direction, uint PixelResolution, uint BidirectionalWeight, uint SadAdjustment) {
            _builder.Append("%OpSubgroupAvcBmeInitializeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + MajorShapes + " ");
            _builder.Append("%" + MinorShapes + " ");
            _builder.Append("%" + Direction + " ");
            _builder.Append("%" + PixelResolution + " ");
            _builder.Append("%" + BidirectionalWeight + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefConvertToMcePayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefConvertToMcePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefSetBidirectionalMixDisableINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefSetBidirectionalMixDisableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefSetBilinearFilterEnableINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefSetBilinearFilterEnableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithSingleReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithDualReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefEvaluateWithDualReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithMultiReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint PackedReferenceIds, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL(uint returnId, uint param1, uint SrcImage, uint PackedReferenceIds, uint PackedReferenceFieldPolarities, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefConvertToMceResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcRefConvertToMceResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicInitializeINTEL(uint returnId, uint param1, uint SrcCoord) {
            _builder.Append("%OpSubgroupAvcSicInitializeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureSkcINTEL(uint returnId, uint param1, uint SkipBlockPartitionType, uint SkipMotionVectorMask, uint MotionVectors, uint BidirectionalWeight, uint SadAdjustment, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicConfigureSkcINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SkipBlockPartitionType + " ");
            _builder.Append("%" + SkipMotionVectorMask + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + BidirectionalWeight + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureIpeLumaINTEL(uint returnId, uint param1, uint LumaIntraPartitionMask, uint IntraNeighbourAvailabilty, uint LeftEdgeLumaPixels, uint UpperLeftCornerLumaPixel, uint UpperEdgeLumaPixels, uint UpperRightEdgeLumaPixels, uint SadAdjustment, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicConfigureIpeLumaINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + LumaIntraPartitionMask + " ");
            _builder.Append("%" + IntraNeighbourAvailabilty + " ");
            _builder.Append("%" + LeftEdgeLumaPixels + " ");
            _builder.Append("%" + UpperLeftCornerLumaPixel + " ");
            _builder.Append("%" + UpperEdgeLumaPixels + " ");
            _builder.Append("%" + UpperRightEdgeLumaPixels + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureIpeLumaChromaINTEL(uint returnId, uint param1, uint LumaIntraPartitionMask, uint IntraNeighbourAvailabilty, uint LeftEdgeLumaPixels, uint UpperLeftCornerLumaPixel, uint UpperEdgeLumaPixels, uint UpperRightEdgeLumaPixels, uint LeftEdgeChromaPixels, uint UpperLeftCornerChromaPixel, uint UpperEdgeChromaPixels, uint SadAdjustment, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicConfigureIpeLumaChromaINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + LumaIntraPartitionMask + " ");
            _builder.Append("%" + IntraNeighbourAvailabilty + " ");
            _builder.Append("%" + LeftEdgeLumaPixels + " ");
            _builder.Append("%" + UpperLeftCornerLumaPixel + " ");
            _builder.Append("%" + UpperEdgeLumaPixels + " ");
            _builder.Append("%" + UpperRightEdgeLumaPixels + " ");
            _builder.Append("%" + LeftEdgeChromaPixels + " ");
            _builder.Append("%" + UpperLeftCornerChromaPixel + " ");
            _builder.Append("%" + UpperEdgeChromaPixels + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetMotionVectorMaskINTEL(uint returnId, uint param1, uint SkipBlockPartitionType, uint Direction) {
            _builder.Append("%OpSubgroupAvcSicGetMotionVectorMaskINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SkipBlockPartitionType + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConvertToMcePayloadINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicConvertToMcePayloadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL(uint returnId, uint param1, uint PackedShapePenalty, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedShapePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL(uint returnId, uint param1, uint LumaModePenalty, uint LumaPackedNeighborModes, uint LumaPackedNonDcPenalty, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + LumaModePenalty + " ");
            _builder.Append("%" + LumaPackedNeighborModes + " ");
            _builder.Append("%" + LumaPackedNonDcPenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL(uint returnId, uint param1, uint ChromaModeBasePenalty, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + ChromaModeBasePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetBilinearFilterEnableINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetBilinearFilterEnableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetSkcForwardTransformEnableINTEL(uint returnId, uint param1, uint PackedSadCoefficients, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PackedSadCoefficients + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL(uint returnId, uint param1, uint BlockBasedSkipType, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + BlockBasedSkipType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateIpeINTEL(uint returnId, uint param1, uint SrcImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicEvaluateIpeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithSingleReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithDualReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicEvaluateWithDualReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithMultiReferenceINTEL(uint returnId, uint param1, uint SrcImage, uint PackedReferenceIds, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL(uint returnId, uint param1, uint SrcImage, uint PackedReferenceIds, uint PackedReferenceFieldPolarities, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConvertToMceResultINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicConvertToMceResultINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetIpeLumaShapeINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetIpeLumaShapeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetBestIpeLumaDistortionINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetBestIpeChromaDistortionINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedIpeLumaModesINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetPackedIpeLumaModesINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetIpeChromaModeINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetIpeChromaModeINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetInterRawSadsINTEL(uint returnId, uint param1, uint Payload) {
            _builder.Append("%OpSubgroupAvcSicGetInterRawSadsINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVariableLengthArrayINTEL(uint returnId, uint param1, uint Lenght) {
            _builder.Append("%OpVariableLengthArrayINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Lenght + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSaveMemoryINTEL(uint returnId, uint param1) {
            _builder.Append("%OpSaveMemoryINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRestoreMemoryINTEL(uint Ptr) {
            _builder.Append("%OpRestoreMemoryINTEL");
            _builder.Append("%" + Ptr + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoopControlINTEL(params uint[] LoopControlParameters) {
            _builder.Append("%OpLoopControlINTEL");
            _builder.Append(LoopControlParameters + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrCastToCrossWorkgroupINTEL(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpPtrCastToCrossWorkgroupINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCrossWorkgroupCastToPtrINTEL(uint returnId, uint param1, uint Pointer) {
            _builder.Append("%OpCrossWorkgroupCastToPtrINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadPipeBlockingINTEL(uint returnId, uint param1, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpReadPipeBlockingINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePipeBlockingINTEL(uint returnId, uint param1, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%OpWritePipeBlockingINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFPGARegINTEL(uint returnId, uint param1, uint Result, uint Input) {
            _builder.Append("%OpFPGARegINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Result + " ");
            _builder.Append("%" + Input + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetRayTMinKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryGetRayTMinKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetRayFlagsKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryGetRayFlagsKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionTKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionTKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceCustomIndexKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionInstanceCustomIndexKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceIdKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionInstanceIdKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionGeometryIndexKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionGeometryIndexKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionPrimitiveIndexKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionPrimitiveIndexKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionBarycentricsKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionBarycentricsKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionFrontFaceKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionFrontFaceKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionCandidateAABBOpaqueKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryGetIntersectionCandidateAABBOpaqueKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectRayDirectionKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionObjectRayDirectionKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectRayOriginKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionObjectRayOriginKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetWorldRayDirectionKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryGetWorldRayDirectionKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetWorldRayOriginKHR(uint returnId, uint param1, uint RayQuery) {
            _builder.Append("%OpRayQueryGetWorldRayOriginKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectToWorldKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionObjectToWorldKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionWorldToObjectKHR(uint returnId, uint param1, uint RayQuery, uint Intersection) {
            _builder.Append("%OpRayQueryGetIntersectionWorldToObjectKHR");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFAddEXT(uint returnId, uint param1, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%OpAtomicFAddEXT");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.Append("%" + param1 + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeBufferSurfaceINTEL(uint returnId) {
            _builder.Append("%OpTypeBufferSurfaceINTEL");
            _builder.Insert(0, "%" + returnId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeStructContinuedINTEL(params uint[] Member0typemember1type) {
            _builder.Append("%OpTypeStructContinuedINTEL");
            _builder.Append("%" + Member0typemember1type + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantCompositeContinuedINTEL(params uint[] Constituents) {
            _builder.Append("%OpConstantCompositeContinuedINTEL");
            _builder.Append("%" + Constituents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantCompositeContinuedINTEL(params uint[] Constituents) {
            _builder.Append("%OpSpecConstantCompositeContinuedINTEL");
            _builder.Append("%" + Constituents + " ");
            _builder.AppendLine();
        }
        
    }
}
#pragma warning restore 1591